using HttpWebTesting;
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
                if(tvi.Name.StartsWith("Root_"))
                {
                    string str = tvi.Name.Replace('_', '.');
                    if (wtim.GetItemTreeType(str) == WebTestItemType.Wti_RequestObject)
                    {
                        WebTestItem selectedItem = wtim.GetActualItem(str, _webTest.WebTestItems);
                        GetWebTestItemCustomProperties(selectedItem);
                        dgPropertyList.ItemsSource = _propertiesDataTable.AsDataView();
                    }
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
                tbResults.Text = _webTestResults.ToString();
            }
            else
            {
                tbResults.Text = "Results were null.";
            }
            tabResultsView.IsSelected = true;
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
