using HttpWebTesting;
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

        public HttpWebTestEditor()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _webTest = HttpWebTestSerializer.DeserializeTest(@"c:\temp\sampleHttpWebTest.json");
            PopulateTreeView();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void tvWebTest_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        private void tvWebTest_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }
    }
}
