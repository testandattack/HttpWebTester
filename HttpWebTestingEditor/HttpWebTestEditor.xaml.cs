using ApiTestGenerator.Models;
using ApiTestGenerator.Models.ApiDocs;
using HttpWebExtensions;
using HttpWebTesting;
using HttpWebTesting.SampleTest;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using Newtonsoft.Json;
using SwaggerParsing;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WebTestExecutionEngine;
using WebTestItemManager;
using GTC.Extensions;
using GTC_HttpArchiveReader;

namespace HttpWebTestingEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HttpWebTestEditor : Window
    {
        private HttpWebTest _webTest;
        private ItemManager wtim;
        private HttpWebTestResults _webTestResults;

        private string _currentlyLoadedFileName;
        private bool _fileWasModified;
        private bool _wordWrap = true;
        private FindReplaceOptions findReplaceOptions;
        private ApiSet _apiSet;

        public HttpWebTestEditor()
        {
            InitializeComponent();
        }

        #region -- Window Event Handlers --------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _currentlyLoadedFileName = "";
            _fileWasModified = false;
            findReplaceOptions = new FindReplaceOptions();
            findReplaceOptions.LoadFindReplaceOptions();
            PopulateFindReplaceProperties();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            findReplaceOptions.SaveFindReplaceOptions();
        }
        #endregion

        #region -- Control Event Handlers -------------------------------------
        private void tvWebTest_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        private void tvWebTest_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem tvi = ((TreeViewItem)e.NewValue);
            if (tvi != null)
            {
                stackProperties.Children.Clear();
                var stackPropertiesWidth = stackProperties.ActualWidth;

                if (tvi.Name.StartsWith("Root_"))
                {
                    string str = tvi.Name.Replace('_', '.');

                    WebTestItem selectedItem = wtim.GetActualItem(str, _webTest.WebTestItems);
                    var props = GetWebTestItemProperties(selectedItem);
                    PopulatePropertiesStack(props, stackPropertiesWidth, selectedItem);
                }
                else if(tvi.Name.StartsWith(TVI_Name_ContextParameter))
                {
                    int x = Int32.Parse(tvi.Name.Substring(TVI_Name_ContextParameter.Length));
                    Dictionary<string, object> props = new Dictionary<string, object>();
                    props.Add("Context Name", _webTest.ContextProperties[x].Name);
                    props.Add("Context Value", _webTest.ContextProperties[x].Value);
                    props.Add("Type", _webTest.ContextProperties[x].Type);
                    PopulatePropertiesStack(props, stackPropertiesWidth, _webTest.ContextProperties[x]);
                }
                else if (tvi.Name.StartsWith(TVI_Name_Headers))
                {
                    WTI_Request parent = GetParentRequest(tvi);
                    if (parent == null)
                        return;

                    int x = Int32.Parse(tvi.Name.Substring(TVI_Name_Headers.Length));
                    Dictionary<string, object> props = new Dictionary<string, object>();
                    props.Add("Header Name", parent.Headers.GetKey(x));
                    props.Add("Header Value", parent.Headers.GetValue(x));
                    PopulatePropertiesStack(props, stackPropertiesWidth, parent.Headers);
                }
                else if (tvi.Name.StartsWith(TVI_Name_QueryParam))
                {
                    WTI_Request parent = GetParentRequest(tvi);
                    if (parent == null)
                        return;

                    int x = Int32.Parse(tvi.Name.Substring(TVI_Name_QueryParam.Length));
                    Dictionary<string, object> props = new Dictionary<string, object>();
                    props.Add("Query Param Name", parent.QueryCollection.queryParams.GetKey(x));
                    props.Add("Query Param Value", parent.QueryCollection.queryParams.GetValue(x));
                    PopulatePropertiesStack(props, stackPropertiesWidth, parent.QueryCollection);
                }
                else if (tvi.Name.StartsWith(TVI_Name_FormParam))
                {
                    WTI_Request parent = GetParentRequest(tvi);
                    if (parent == null)
                        return;

                    int x = Int32.Parse(tvi.Name.Substring(TVI_Name_FormParam.Length));
                    Dictionary<string, object> props = new Dictionary<string, object>();
                    props.Add("Form Post Param Name", parent.FormPostParams.GetKey(x));
                    props.Add("Form Post Param Value", parent.FormPostParams.GetValue(x));
                    PopulatePropertiesStack(props, stackPropertiesWidth, parent.Content);
                }
                else if (tvi.Name.StartsWith(TVI_Name_TestRule))
                {
                    int x = Int32.Parse(tvi.Name.Substring(TVI_Name_TestRule.Length));
                    var props = GetTestLevelItemProperties(_webTest.Rules[x]);
                    PopulatePropertiesStack(props, stackPropertiesWidth, _webTest.Rules[x]);
                }
                else if (tvi.Name.StartsWith(TVI_Name_DataSource))
                {
                    int x = Int32.Parse(tvi.Name.Substring(TVI_Name_DataSource.Length));
                    var props = GetTestLevelItemProperties(_webTest.DataSources[x]);
                    PopulatePropertiesStack(props, stackPropertiesWidth, _webTest.DataSources[x]);
                }
                else if (tvi.Name == TVI_Name_RecordedResponse)
                {
                    // String body response is directly below thge request IN THE TREEVIEW
                    // so do not go up 2 levels to figure out the actual request item.
                    WTI_Request parent = GetParentRequest(tvi, false);
                    if (parent == null)
                        return;

                    tbResponseBody.Text = parent.RecordedResponseBody;
                    tabResponseBody.IsSelected = true;
                }
            }
        }

        private WTI_Request GetParentRequest(TreeViewItem tvi, bool useGrandParentItem = true)
        {
            TreeViewItem parent = tvi.Parent as TreeViewItem;
            if (useGrandParentItem == true)
            {
                TreeViewItem grandParent = parent.Parent as TreeViewItem;
                if (grandParent.Name.StartsWith("Root_"))
                {
                    string str = grandParent.Name.Replace('_', '.');
                    return wtim.GetActualItem(str, _webTest.WebTestItems) as WTI_Request;
                }

            }

            else
            {
                if (parent.Name.StartsWith("Root_"))
                {
                    string str = parent.Name.Replace('_', '.');
                    return wtim.GetActualItem(str, _webTest.WebTestItems) as WTI_Request;
                }
            }
            return null;
        }

        private void tvWebTestResults_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem tvi = ((TreeViewItem)e.NewValue);
            if (tvi != null)
            {
                tabResponseBody.IsSelected = true;
                if (tvi.Tag != null)
                {
                    tbResponseBody.Text = (tvi.Tag as WTRI_Request).responseBody;
                    tbRequestBody.Text = (tvi.Tag as WTRI_Request).RequestAsSent.GetRequestBody();
                }

            }
        }

        private void tvAPI_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem tvi = ((TreeViewItem)e.NewValue);
            if (tvi != null && _apiSet != null)
            {
                stackProperties.Children.Clear();
                var stackPropertiesWidth = stackProperties.ActualWidth;

                if (tvi.Name.StartsWith("Root_"))
                {
                    // Show the info set
                    Dictionary<string, object> props = new Dictionary<string, object>();
                    props.Add("Title", _apiSet.Info.Title ?? "");
                    props.Add("Description", _apiSet.Info.Description ?? "");
                    props.Add("Version", _apiSet.Info.Version ?? "");
                    props.Add("Terms Of Service", _apiSet.Info.TermsOfService);
                    if(_apiSet.Info.Contact != null)
                        props.Add("Contact", JsonConvert.SerializeObject(_apiSet.Info.Contact, Formatting.Indented));
                    if (_apiSet.Info.License != null)
                        props.Add("License", JsonConvert.SerializeObject(_apiSet.Info.License, Formatting.Indented));
                    PopulatePropertiesStack(props, stackPropertiesWidth, _apiSet.Info);
                }
                else if (tvi.Name.StartsWith(TVI_Name_Endpoints))
                {
                    int x = Int32.Parse(tvi.Name.Substring(TVI_Name_Endpoints.Length));
                    Dictionary<string, object> props = new Dictionary<string, object>();
                    //props.Add("Context Name", _webTest.ContextProperties[x].Name);
                    //props.Add("Context Value", _webTest.ContextProperties[x].Value);
                    //props.Add("Type", _webTest.ContextProperties[x].Type);
                    //PopulatePropertiesStack(props, stackPropertiesWidth, _webTest.ContextProperties[x]);
                }
                else if (tvi.Name.StartsWith(TVI_Name_Headers))
                {
                    WTI_Request parent = GetParentRequest(tvi);
                    if (parent == null)
                        return;

                    int x = Int32.Parse(tvi.Name.Substring(TVI_Name_Headers.Length));
                    Dictionary<string, object> props = new Dictionary<string, object>();
                    props.Add("Header Name", parent.Headers.GetKey(x));
                    props.Add("Header Value", parent.Headers.GetValue(x));
                    PopulatePropertiesStack(props, stackPropertiesWidth, parent.Headers);
                }
                else if (tvi.Name.StartsWith(TVI_Name_QueryParam))
                {
                    WTI_Request parent = GetParentRequest(tvi);
                    if (parent == null)
                        return;

                    int x = Int32.Parse(tvi.Name.Substring(TVI_Name_QueryParam.Length));
                    Dictionary<string, object> props = new Dictionary<string, object>();
                    props.Add("Query Param Name", parent.QueryCollection.queryParams.GetKey(x));
                    props.Add("Query Param Value", parent.QueryCollection.queryParams.GetValue(x));
                    PopulatePropertiesStack(props, stackPropertiesWidth, parent.QueryCollection);
                }
                else if (tvi.Name.StartsWith(TVI_Name_TestRule))
                {
                    int x = Int32.Parse(tvi.Name.Substring(TVI_Name_TestRule.Length));
                    var props = GetTestLevelItemProperties(_webTest.Rules[x]);
                    PopulatePropertiesStack(props, stackPropertiesWidth, _webTest.Rules[x]);
                }
                else if (tvi.Name.StartsWith(TVI_Name_DataSource))
                {
                    int x = Int32.Parse(tvi.Name.Substring(TVI_Name_DataSource.Length));
                    var props = GetTestLevelItemProperties(_webTest.DataSources[x]);
                    PopulatePropertiesStack(props, stackPropertiesWidth, _webTest.DataSources[x]);
                }

            }
        }
        #endregion

        #region -- Response Text Box Menu Event Handlers -----
        private void cmiWordWrap_Click(object sender, RoutedEventArgs e)
        {
            _wordWrap = !_wordWrap;
            cmiWordWrap.IsChecked = _wordWrap;
            tbResponseBody.TextWrapping = _wordWrap ? TextWrapping.Wrap : TextWrapping.NoWrap;
        }

        private void cmiExpandJson_Click(object sender, RoutedEventArgs e)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(tbResponseBody.Text);
            tbResponseBody.Text = JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }
        #endregion

        #region -- Menu Item Event Handlers -----------------------------------
        #region -- File Menu -----
        private void tsmiOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Use the Win32 OpenFileDialog to allow the user to pick a file ...
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.DefaultExt = ".json";
                ofd.Filter = "HttpWebTest Files (*.json)|*.json|All Files (*.*)|*.*";
                Nullable<bool> fUserPickedFile = ofd.ShowDialog(this);
                if (fUserPickedFile == true)
                {
                    _currentlyLoadedFileName = ofd.FileName;
                    _webTest = HttpWebTestSerializer.DeserializeTest(_currentlyLoadedFileName);
                    wtim = new ItemManager(_webTest);
                    tabTreeView.Header = _currentlyLoadedFileName.Substring(_currentlyLoadedFileName.LastIndexOf('\\') + 1);
                    PopulateTreeView();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private void tsmiOpenResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Use the Win32 OpenFileDialog to allow the user to pick a file ...
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.DefaultExt = ".json";
                ofd.Filter = "HttpWebTest Results Files (*.json)|*.json|All Files (*.*)|*.*";
                Nullable<bool> fUserPickedFile = ofd.ShowDialog(this);
                if (fUserPickedFile == true)
                {
                    _currentlyLoadedFileName = ofd.FileName;
                    _webTestResults = HttpWebTestSerializer.DeserializeTestResults(_currentlyLoadedFileName);
                    _webTest = _webTestResults.originalWebTest;
                    wtim = new ItemManager(_webTest);
                    tabResultsTreeView.Header = _currentlyLoadedFileName.Substring(_currentlyLoadedFileName.LastIndexOf('\\') + 1);
                    tabTreeView.Header = _webTest.Name;
                    PopulateTreeView();
                    PopulateResultsTreeView();
                    tabResultsTreeView.IsSelected = true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private void tsmiOpenHar_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    //Use the Win32 OpenFileDialog to allow the user to pick a file ...
            //    Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            //    ofd.DefaultExt = ".har";
            //    ofd.Filter = "HttpArchive Files (*.har)|*.har|All Files (*.*)|*.*";
            //    Nullable<bool> fUserPickedFile = ofd.ShowDialog(this);
            //    if (fUserPickedFile == true)
            //    {
            //        _currentlyLoadedFileName = ofd.FileName;
            //        HttpArchiveReader harReader = new HttpArchiveReader();
            //        harReader.LoadArchive(ofd.FileName);
            //        harReader.BuildSortedListOfRequests();
            //        harReader.BuildVsWebtest();
            //        harReader.SaveLogFile(ofd.FileName.Replace(".har", ".log"));
            //        harReader.SaveNewVsWebtest(ofd.FileName.Replace(".har", ".webtest"));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.MessageBox.Show(ex.ToString());
            //}
        }

        private void tsmiAppExit_Click(object sender, RoutedEventArgs e)
        {
            if (SaveModifiedFile())
                this.Close();
        }
        #endregion

        #region -- Testing Menu -----
        private void tsmiExecute_Click(object sender, RoutedEventArgs e)
        {
            if (_webTest == null)
            {
                MessageBox.Show("No web test loaded. Please load a webtest, then try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ExecutionEngine engine = new ExecutionEngine(_webTest);
            _webTestResults = engine.ExecuteTheTests();
            
            if(_webTestResults != null)
            {
                //_updatingDataGrid = true;
                //dgTestResults.ItemsSource = _webTestResults.GetResultsAsTable().AsDataView();
                //_updatingDataGrid = false;
                PopulateResultsTreeView();
            }
            tabResultsTreeView.IsSelected = true;
        }

        private void tsmiCreateTestFromHar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Use the Win32 OpenFileDialog to allow the user to pick a file ...
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.DefaultExt = ".har";
                ofd.Filter = "HttpArchive Files (*.har)|*.har|All Files (*.*)|*.*";
                Nullable<bool> fUserPickedFile = ofd.ShowDialog(this);
                if (fUserPickedFile == true)
                {
                    _currentlyLoadedFileName = ofd.FileName;
                    HttpArchiveReader harReader = new HttpArchiveReader();
                    harReader.LoadArchive(ofd.FileName);
                    harReader.BuildSortedListOfRequests();
                    harReader.BuildWebtest();
                    harReader.SaveLogFile(ofd.FileName.Replace(".har", ".log"));
                    harReader.SaveNewWebtest(ofd.FileName.Replace(".har", ".json"));

                    _webTest = HttpWebTestSerializer.DeserializeTest(ofd.FileName.Replace(".har", ".json"));
                    wtim = new ItemManager(_webTest);
                    tabTreeView.Header = _currentlyLoadedFileName.Substring(_currentlyLoadedFileName.LastIndexOf('\\') + 1);
                    PopulateTreeView();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private void tsmiCreateSampleTest_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog ofd = new Microsoft.Win32.SaveFileDialog();
            ofd.DefaultExt = ".json";
            ofd.Filter = "HttpWebTest Files (*.json)|*.json|All Files (*.*)|*.*";
            Nullable<bool> fUserPickedFile = ofd.ShowDialog(this);
            if (fUserPickedFile == true)
            {
                Sample sample = new Sample(ofd.FileName.Replace(".json",".csv"));
                HttpWebTestSerializer.SerializeAndSaveTest(sample.httpWebTest, ofd.FileName);
                _webTest = sample.httpWebTest;
                _currentlyLoadedFileName = ofd.FileName;
                wtim = new ItemManager(_webTest);
                tabTreeView.Header = _currentlyLoadedFileName.Substring(_currentlyLoadedFileName.LastIndexOf('\\') + 1);
                PopulateTreeView();
            }
        }
        #endregion

        #region -- OAS Menu -----
        private void tsmiReadOasFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Use the Win32 OpenFileDialog to allow the user to pick a file ...
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.DefaultExt = ".json";
                ofd.Filter = "Open API Spec Files (*.json)|*.json|All Files (*.*)|*.*";
                Nullable<bool> fUserPickedFile = ofd.ShowDialog(this);
                if (fUserPickedFile == true)
                {
                    Settings settings = Settings.LoadSettings("settings.json");
                    settings.swaggerSettings.SwaggerFileLocation = ofd.FileName;
                    SwaggerParser sp = new SwaggerParser(settings);
                    sp.PopulateApiDocument(true);
                    tsslMessage.Content = $"Read {ofd.FileName.ExcludePath()} completed.";
                    tsslMessage.Refresh();

                    sp.SaveOriginalSwaggerDocument();
                    ApiSet apiSet = sp.BuildApiSetFromOpenApiDocument();
                    apiSet.SerializeAndSaveApiSet();
                    tsslMessage.Content = $"Build API set from {ofd.FileName.ExcludePath()} completed.";
                    tsslMessage.Refresh();

                    PopulateAPITreeView(apiSet);
                    tabApiTreeView.IsSelected = true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private void tsmiReadOasStream_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature not currently implemented.");
        }
        #endregion

        #region -- APISet Menu -----
        private void tsmiReadApiSetFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Use the Win32 OpenFileDialog to allow the user to pick a file ...
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.DefaultExt = ".json";
                ofd.Filter = "ApiSet Files (*.json)|*.json|All Files (*.*)|*.*";
                Nullable<bool> fUserPickedFile = ofd.ShowDialog(this);
                if (fUserPickedFile == true)
                {
                    _currentlyLoadedFileName = ofd.FileName;
                    _apiSet = ApiSet.LoadApiSetFromFile(ofd.FileName);
                    tabApiTreeView.Header = _currentlyLoadedFileName.Substring(_currentlyLoadedFileName.LastIndexOf('\\') + 1);
                    PopulateAPITreeView(_apiSet);
                    tabApiTreeView.IsSelected = true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private void tsmiSaveApiSet_Click(object sender, RoutedEventArgs e)
        {
        }
        #endregion
        #endregion

        #region -- Utility Methods -----
        private bool SaveModifiedFile()
        {
            if (_fileWasModified)
            {
                MessageBoxResult dlg = System.Windows.MessageBox.Show("File has been modified. Do you want to save the changes?\r\n", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (dlg == MessageBoxResult.Yes)
                {
                    if (_currentlyLoadedFileName.EndsWith(" *"))
                        _currentlyLoadedFileName = _currentlyLoadedFileName.Remove(_currentlyLoadedFileName.LastIndexOf(" *"));
                    HttpWebTestSerializer.SerializeAndSaveTest(_webTest, _currentlyLoadedFileName);
                    _fileWasModified = false;
                    return true;
                }
                else if (dlg == MessageBoxResult.No)
                {
                    _fileWasModified = false;
                    return true;
                }
                else  // User selected 'Cancel'
                {
                    return false;
                }
            }
            else
                return true;
        }

        private void PopulateFindReplaceProperties()
        {
            foreach (var prop in findReplaceOptions.GetType().GetProperties())
            {
                var propValue = prop.GetValue(findReplaceOptions, null);
                if (propValue != null)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.IsChecked = (bool)propValue;
                    checkBox.Content = prop.Name;
                    stackFindReplaceProperties.Children.Add(checkBox);
                }
            }
        }

        #endregion
    }
}
