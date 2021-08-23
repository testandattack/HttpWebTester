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

namespace HttpWebTestingEditor
{
    public partial class HttpWebTestEditor : Window
    {
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
            treeItem.Header = CustomizeTreeViewItem(wtr.requestItem.RequestUri.AbsoluteUri, (BitmapImage)Properties.Resources.WebRequest_24.ToWpfBitmap());

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
                subItem.Name = String.Format("ContextParameter_{0}", x++);
                treeItem.Items.Add(subItem);
            }
        }

        private void AddRequestLevelRules(TreeViewItem parentItem)
        {
            RuleCollection rules = _webTest.Rules.GetRulesOfType(RuleTypes_Enums.RequestRule_PreRequest);
            rules.AddRange(_webTest.Rules.GetRulesOfType(RuleTypes_Enums.RequestRule_Validation));
            rules.AddRange(_webTest.Rules.GetRulesOfType(RuleTypes_Enums.RequestRule_Extraction));
            rules.AddRange(_webTest.Rules.GetRulesOfType(RuleTypes_Enums.RequestRule_PostRequest));

            if (rules.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Rules", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "RequestLevelRules";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var rule in rules)
            {
                TreeViewItem subItem = new TreeViewItem();
                subItem.Header = CustomizeTreeViewItem(rule.Name, (BitmapImage)Properties.Resources.RequestPlugin_24.ToWpfBitmap());
                subItem.Name = String.Format("RequestLevelRules_{0}", x++);
                treeItem.Items.Add(subItem);
            }
        }

        private void AddTestLevelRules(TreeViewItem parentItem)
        {
            RuleCollection rules = _webTest.Rules.GetRulesOfType(RuleTypes_Enums.PreTest);
            rules.AddRange(_webTest.Rules.GetRulesOfType(RuleTypes_Enums.TestRule_PreRequest));
            rules.AddRange(_webTest.Rules.GetRulesOfType(RuleTypes_Enums.TestRule_Validation));
            rules.AddRange(_webTest.Rules.GetRulesOfType(RuleTypes_Enums.TestRule_Extraction));
            rules.AddRange(_webTest.Rules.GetRulesOfType(RuleTypes_Enums.TestRule_PostRequest));
            rules.AddRange(_webTest.Rules.GetRulesOfType(RuleTypes_Enums.PostTest));

            if (rules.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Rules", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "TestLevelRules";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var rule in rules)
            {
                TreeViewItem subItem = new TreeViewItem();
                subItem.Header = CustomizeTreeViewItem(rule.Name, (BitmapImage)Properties.Resources.RequestPlugin_24.ToWpfBitmap());
                subItem.Name = String.Format("TestLevelRules_{0}", x++);
                treeItem.Items.Add(subItem);
            }
        }
    }

    public class tvStackPanel : StackPanel
    {
        public int TreeViewItemId { get; set; }

    }
 }
