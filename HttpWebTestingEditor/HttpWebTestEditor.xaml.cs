using HttpWebTesting;
using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
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
using WebTestItemManager;

namespace HttpWebTestingEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HttpWebTestEditor : Window
    {
        private HttpWebTest _webTest;
        private string _currentlyLoadedFileName;
        private bool _fileWasModified;

        public HttpWebTestEditor()
        {
            InitializeComponent();
        }

        #region -- Window Event Handlers --------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _currentlyLoadedFileName = "";
            _fileWasModified = false;
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
                string str = tvi.Name;

                WTI_Request aRequest = _webTest.WebTestItems[2] as WTI_Request;

                Console.WriteLine("");
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
                    HttpWebTestSerializer.SerializeTest(_webTest, _currentlyLoadedFileName);
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
