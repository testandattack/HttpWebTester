using HttpWebTesting.Collections;
using HttpWebTesting.CoreObjects;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GTC.Extensions;
using HttpWebTesting.Rules;
using System.Collections;
using System.Net.Http;

namespace HttpWebTestingEditor
{
    public partial class HttpWebTestEditor : Window
    {
        private const string TVI_Name_ContextParameter = "ContextParameter_";
        private const string TVI_Name_TestRule = "TestLevelRules_";
        private const string TVI_Name_DataSource = "DataSources_";

        #region -- Treeview Population Methods -----
        private void PopulateTreeView()
        {
            tvWebTest.Items.Clear();

            // Set the root WebTest Node
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem(_webTest.Name, (BitmapImage)Properties.Resources.WebTest_24.ToWpfBitmap());
            treeItem.Name = "Root";

            // Walk the webtest and add dependent items
            RecurseTheWebTestItemCollection(_webTest.WebTestItems, treeItem);

            //// Add the webtest collections to the tree
            //AddDataSources(treeItem);
            AddContextParameters(treeItem);
            AddTestLevelRules(treeItem);

            //Add the entire list to the tree 
            tvWebTest.Items.Add(treeItem);

            // expand tree to the first level
            treeItem.IsExpanded = true;
        }

        private StackPanel CustomizeTreeViewItem(object itemObj, BitmapImage bmi, int tvItemId = 0)
        {
            return CustomizeTreeViewItem(itemObj, bmi, Colors.White, tvItemId);
        }

        private StackPanel CustomizeTreeViewItem(object itemObj, BitmapImage bmi, System.Windows.Media.Color color, int tvItemId = 0)
        {
            // Create Stack Panel
            tvStackPanel stkPanel = new tvStackPanel();
            stkPanel.Orientation = Orientation.Horizontal;
            stkPanel.TreeViewItemId = tvItemId;

            // Create Image
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            img.Source = bmi;
            img.Width = 16;
            img.Height = 16;
            ThicknessConverter tc = new ThicknessConverter();
            img.Margin = (Thickness)tc.ConvertFromString("2");

            // Create TextBlock
            TextBlock lbl = new TextBlock();
            lbl.Text = " " + itemObj.ToString();
            lbl.VerticalAlignment = VerticalAlignment.Center;
            if (color != Colors.White)
            {
                lbl.Background = new SolidColorBrush(color);
            }
            // Add to stack
            stkPanel.Children.Add(img);
            stkPanel.Children.Add(lbl);

            return stkPanel;
        }

        private void RecurseTheWebTestItemCollection(WebTestItemCollection items, TreeViewItem parentTreeViewItem)
        {
            for (int nIndex = 0; nIndex < items.Count; nIndex++)
            {
                TreeViewItem treeItem = new TreeViewItem();
                treeItem.Name = parentTreeViewItem.Name + "_" + nIndex.ToString();

                #region === Request object ==============================
                if (items[nIndex] is WTI_Request)
                {
                    parentTreeViewItem.Items.Add(ProcessRequestItem(items[nIndex], parentTreeViewItem, nIndex));
                }
                #endregion

                #region === Comment =====================================
                else if (items[nIndex] is WTI_Comment)
                {
                    WTI_Comment cmt = items[nIndex] as WTI_Comment;
                    treeItem.Header = CustomizeTreeViewItem(cmt.CommentText, (BitmapImage)Properties.Resources.Comment_24.ToWpfBitmap());
                    parentTreeViewItem.Items.Add(treeItem);
                }
                #endregion

                #region === Transaction Timer ===========================
                else if (items[nIndex] is WTI_Transaction)
                {
                    WTI_Transaction transaction = items[nIndex] as WTI_Transaction;
                    treeItem.Header = CustomizeTreeViewItem(transaction.Name, (BitmapImage)Properties.Resources.TransactionTimer_24.ToWpfBitmap());
                    parentTreeViewItem.Items.Add(treeItem);
                    RecurseTheWebTestItemCollection(transaction.webTestItems, treeItem);
                }
                #endregion

                #region === Web Test Loop ===============================
                else if (items[nIndex] is WTI_LoopControl)
                {
                    WTI_LoopControl loop = items[nIndex] as WTI_LoopControl;
                    treeItem.Header = CustomizeTreeViewItem(loop.GetLoopControlDisplayName(), (BitmapImage)Properties.Resources.WebTestLoop_24.ToWpfBitmap());
                    parentTreeViewItem.Items.Add(treeItem);
                    RecurseTheWebTestItemCollection(loop.webTestItems, treeItem);
                }
                #endregion

                #region === Included Web Test ===========================
                else if (items[nIndex] is WTI_IncludedWebTest)
                {
                    WTI_IncludedWebTest _webTest = items[nIndex] as WTI_IncludedWebTest;
                    treeItem.Header = CustomizeTreeViewItem(_webTest.Name, (BitmapImage)Properties.Resources.WebTestCondition_24.ToWpfBitmap());
                    parentTreeViewItem.Items.Add(treeItem);
                }
                #endregion

                #region === Unknown item type ===========================
                #endregion
            }
            return;
        }

        private TreeViewItem ProcessRequestItem(WebTestItem item, TreeViewItem parentTreeViewItem, int nIndex)
        {
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Name = parentTreeViewItem.Name + "_" + nIndex.ToString();

            WTI_Request wtr = (WTI_Request)item;
            string itemLabel = $"{wtr.Method.ToString().ToUpper()}  {wtr.RequestUri.AbsoluteUri.UrlDecode()}";
            treeItem.Header = CustomizeTreeViewItem(itemLabel, (BitmapImage)Properties.Resources.WebRequest_24.ToWpfBitmap());
            AddRequestLevelRules(treeItem, wtr);
            return treeItem;
        }

        private void AddContextParameters(TreeViewItem parentItem)
        {
            if (_webTest.ContextProperties.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Context Parameters", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "ContextParameters";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (Property param in _webTest.ContextProperties)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("{0} = {1}", param.Name, param.Value);
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.Resources.ContextParameter_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_ContextParameter, x++);
                treeItem.Items.Add(subItem);
            }
        }

        private void AddRequestLevelRules(TreeViewItem parentItem, WTI_Request request)
        {

            if (request.Rules.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Rules", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "RequestLevelRules";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var rule in request.Rules)
            {
                TreeViewItem subItem = new TreeViewItem();
                string ruleDisplayName;
                if (rule.RuleType == RuleType.RequestRule_Extraction)
                {
                    string contextName = (rule as ExtractionRule).ContextName;
                    ruleDisplayName = $"{rule.Name} to: {contextName.AddBraces()}";
                }
                else
                {
                    ruleDisplayName = $"{rule.Name}";
                }
                subItem.Header = CustomizeTreeViewItem(ruleDisplayName, (BitmapImage)Properties.Resources.RequestPlugin_24.ToWpfBitmap());
                subItem.Name = String.Format("RequestLevelRules_{0}", x++);
                treeItem.Items.Add(subItem);
            }
        }

        private void AddTestLevelRules(TreeViewItem parentItem)
        {

            if (_webTest.Rules.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Rules", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "TestLevelRules";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var rule in _webTest.Rules)
            {
                TreeViewItem subItem = new TreeViewItem();
                subItem.Header = CustomizeTreeViewItem(rule.Name, (BitmapImage)Properties.Resources.RequestPlugin_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_TestRule, x++);
                treeItem.Items.Add(subItem);
            }
        }

        private void AddDataSources(TreeViewItem parentItem)
        {

            if (_webTest.DataSources.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Data Sources", (BitmapImage)Properties.Resources.DataSources_24.ToWpfBitmap());
            treeItem.Name = "DataSources";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var dataSource in _webTest.DataSources)
            {
                TreeViewItem subItem = new TreeViewItem();
                subItem.Header = CustomizeTreeViewItem(dataSource.Name, (BitmapImage)Properties.Resources.DataSource_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_DataSource, x++);
                treeItem.Items.Add(subItem);
            }
        }
        #endregion

        #region -- Property Display Methods -----
        private void PopulatePropertiesStack(Dictionary<string, object> props, double width, object webTestItem)
        {
            foreach (var item in props)
            {
                TextBlock block = new TextBlock();
                block.Text = item.Key;
                block.Width = 100;

                StackPanel stack = new StackPanel();
                stack.Orientation = Orientation.Horizontal;
                stack.Margin = new Thickness(3);

                stack.Children.Add(block);
                bool IsTypeDescriptor = (item.Key == "Type") ? true : false;
                stack.Children.Add(GetPropertyValueDisplayElement(item.Value, width - 120, IsTypeDescriptor));
                stackProperties.Children.Add(stack);
            }
            stackProperties.Tag = webTestItem;
        }

        private UIElement GetPropertyValueDisplayElement(object propertyItem, double width, bool IsTypeDescriptor = false)
        {
            if(IsTypeDescriptor == true)
                return GetGuidText(propertyItem.ToString(), width);

            else if (propertyItem.GetType() == typeof(System.String))
                return GetTextBox(propertyItem, width);

            else if (propertyItem.GetType() == typeof(System.Net.Http.HttpMethod))
                return GetTextBox(((HttpMethod)propertyItem).Method, width);

            else if (propertyItem.GetType() == typeof(System.Uri))
                return GetTextBox(((Uri)propertyItem).AbsoluteUri.UrlDecode(), width);

            else if (propertyItem.GetType() == typeof(System.Guid))
                return GetGuidText(propertyItem.ToString(), width);

            else if (propertyItem.GetType() == typeof(System.Boolean))
                return GetCheckBox(propertyItem, width);

            else if (propertyItem.GetType() == typeof(System.Int32) ||
                propertyItem.GetType() == typeof(System.Double) ||
                propertyItem.GetType() == typeof(System.Decimal) ||
                propertyItem.GetType() == typeof(System.Single))
                return GetNumberTextBox(propertyItem, width);

            else if (propertyItem.GetType().GetInterface(nameof(ICollection)) != null)
                return GetCollectionView(propertyItem, width);

            else return CheckForEnum(propertyItem, width);
        }

        private UIElement GetTextBox(object propertyItem, double width)
        {
            TextBox box = new TextBox();
            box.Text = (string)propertyItem;
            box.Width = width;
            return box;
        }

        private UIElement GetCheckBox(object propertyItem, double width)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.IsChecked = (bool)propertyItem;
            return checkBox;
        }

        private UIElement GetNumberTextBox(object propertyItem, double width)
        {
            TextBox box = new TextBox();
            box.Text = propertyItem.ToString();
            box.MinWidth = 50;
            return box;
        }

        private UIElement GetGuidText(object propertyItem, double width)
        {
            TextBlock box = new TextBlock();
            box.Text = propertyItem.ToString();
            return box;
        }

        private UIElement GetCollectionView(object propertyItem, double width)
        {
            ListBox listBox = new ListBox();
            foreach (var item in (ICollection)propertyItem)
            {
                ListBoxItem newItem = new ListBoxItem();
                newItem.Content = item;
                listBox.Items.Add(newItem);
            }
            listBox.Width = width;
            //comboBox.Text = "<Collection>";
            return listBox;


            //ComboBox comboBox = new ComboBox();
            //comboBox.IsEditable = true;
            //foreach (var item in (ICollection)propertyItem)
            //{
            //    ComboBoxItem newItem = new ComboBoxItem();
            //    newItem.Content = item;
            //    comboBox.Items.Add(newItem);
            //}
            //comboBox.Width = width;
            //comboBox.Text = "<Collection>";
            //return comboBox;
        }

        private UIElement GetEnumView(object propertyItem, double width)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.IsEditable = false;
            var enumNames = Enum.GetNames((propertyItem.GetType()));
            foreach (string item in enumNames)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = item;
                if (item == propertyItem.ToString())
                    newItem.IsSelected = true;
                comboBox.Items.Add(newItem);
            }
            comboBox.Width = width;

            comboBox.SelectedItem = propertyItem.ToString();
            return comboBox;
        }

        private UIElement CheckForEnum(object propertyItem, double width)
        {
            if (propertyItem.GetType() == typeof(WebTestItemType) ||
                propertyItem.GetType() == typeof(BaseRuleType) ||
                propertyItem.GetType() == typeof(ControlComparisonScope) ||
                propertyItem.GetType() == typeof(DataSourceCursorType) ||
                propertyItem.GetType() == typeof(DataSourceType) ||
                propertyItem.GetType() == typeof(RuleResult) ||
                propertyItem.GetType() == typeof(RuleType))
            {
                return GetEnumView(propertyItem, width);
            }
            else if(propertyItem.GetType() == typeof(ComparisonType))
            {
                // Eventually this one needs to incorporate the AsString() extension
                return GetEnumView(propertyItem, width);
            }
            else return GetGuidText("Undetermined Item Type", width);
        }
        #endregion
    }

    public class tvStackPanel : StackPanel
    {
        public int TreeViewItemId { get; set; }

    }
 }
