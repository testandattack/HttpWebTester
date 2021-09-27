﻿using HttpWebTesting;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebTestExecutionEngine;
using WebTestItemManager;
using HttpWebTestingResults;
using HttpWebTesting.SampleTest;
using System.IO;
using Serilog;

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
        private DataTable _propertiesDataTable;

        public HttpWebTestEditor()
        {
            InitializeComponent();
        }

        #region -- Window Event Handlers --------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _currentlyLoadedFileName = "";
            _fileWasModified = false;
            CreatePropertiesDataTable();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
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

        #region -- Menu Item Event Handlers -----------------------------------
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

        private void tsmiAppExit_Click(object sender, RoutedEventArgs e)
        {
            if (SaveModifiedFile())
                this.Close();
        }

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
                dgTestResults.ItemsSource = _webTestResults.GetResultsAsTable().AsDataView();
            }
            tabResultsTreeView.IsSelected = true;
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
    }
}
