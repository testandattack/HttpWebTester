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
using HttpWebTestingResults;
using System.Net;

namespace HttpWebTestingEditor
{
    public partial class HttpWebTestEditor : Window
    {
        private double _resultsTreeViewWidth;
        private double _rtvWidth_Url_Max;
        private double _rtvWidth_ResponseTime;
        private double _rtvWidth_Status;
        private double _rtvWidth_Code;
        private double _rtvWidth_Payload;
        private int _treeCurrentDepth;
        
        #region -- Treeview Population Methods -----
        private void PopulateResultsTreeView()
        {
            tvWebTestResults.Items.Clear();
            SetTreeViewWidths();

            // Set the root WebTest Node
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem(_webTestResults.Name, (BitmapImage)Properties.Resources.WebTest_24.ToWpfBitmap());
            treeItem.Name = "Root";

            // Walk the webtest and add dependent items
            RecurseTheWebTestResultsItemCollection(_webTestResults.webTestResultsItems, treeItem);


            //Add the entire list to the tree 
            tvWebTestResults.Items.Add(treeItem);

            // expand tree to the first level
            treeItem.IsExpanded = true;
        }

        private void SetTreeViewWidths()
        {

            if(System.Double.IsNaN(tvWebTestResults.ActualWidth) || tvWebTestResults.ActualWidth == 0)
                _resultsTreeViewWidth = 840;
            else
                _resultsTreeViewWidth = tvWebTestResults.ActualWidth;

            _rtvWidth_Code = 50;
            _rtvWidth_Status = 80;
            _rtvWidth_ResponseTime = 80;
            _rtvWidth_Payload = 80;
            _rtvWidth_Url_Max = _resultsTreeViewWidth - (_rtvWidth_Code + _rtvWidth_Status + _rtvWidth_ResponseTime + _rtvWidth_Payload);
            
            // Also set the "header column width"
            tbResultsTreeViewHeader_Name.Width = _rtvWidth_Url_Max;
            _treeCurrentDepth = 2;
        }

        private StackPanel CustomizeResultsTreeViewItem(WebTestResultsItem itemObj, BitmapImage bmi, int tvItemId = 0)
        {
            return CustomizeResultsTreeViewItem(itemObj, bmi, Colors.White, tvItemId);
        }

        private StackPanel CustomizeResultsTreeViewItem(WebTestResultsItem itemObj, BitmapImage bmi, System.Windows.Media.Color color, int tvItemId = 0)
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

            // Get Values for the item
            List<string> values = GetItemText(itemObj);

            // Create Main Entry
            TextBlock lbl = new TextBlock();
            lbl.Width = _rtvWidth_Url_Max - (_treeCurrentDepth * 19); // Default TreeView Indent Size
            lbl.MaxWidth = _rtvWidth_Url_Max - (_treeCurrentDepth * 19); // Default TreeView Indent Size
            lbl.Text = " " + values[0];
            lbl.VerticalAlignment = VerticalAlignment.Center;
            if (color != Colors.White)
            {
                lbl.Background = new SolidColorBrush(color);
            }

            // Create Code Entry
            TextBlock code = new TextBlock();
            code.Width = _rtvWidth_Code;
            code.Text = values[1];
            code.VerticalAlignment = VerticalAlignment.Center;
            if (color != Colors.White)
            {
                code.Background = new SolidColorBrush(color);
            }

            // Create Status Entry
            TextBlock status = new TextBlock();
            status.Width = _rtvWidth_Status;
            status.Text = values[2];
            status.VerticalAlignment = VerticalAlignment.Center;
            if (color != Colors.White)
            {
                status.Background = new SolidColorBrush(color);
            }

            // Create Time Entry
            TextBlock time = new TextBlock();
            time.Width = _rtvWidth_ResponseTime;
            time.Text = values[3];
            time.VerticalAlignment = VerticalAlignment.Center;
            if (color != Colors.White)
            {
                time.Background = new SolidColorBrush(color);
            }

            // Create Size Entry
            TextBlock payload = new TextBlock();
            payload.Width = _rtvWidth_Payload;
            payload.Text = values[4];
            payload.VerticalAlignment = VerticalAlignment.Center;
            if (color != Colors.White)
            {
                time.Background = new SolidColorBrush(color);
            }

            // Add to stack
            stkPanel.Children.Add(img);
            stkPanel.Children.Add(lbl);
            stkPanel.Children.Add(code);
            stkPanel.Children.Add(status);
            stkPanel.Children.Add(time);
            stkPanel.Children.Add(payload);

            return stkPanel;
        }

        private List<string> GetItemText(WebTestResultsItem item)
        {
            List<string> itemValues = new List<string>();
            if(item.objectItemType == WebTestResultItemType.Wtri_RequestObject)
            {
                var request = item as WTRI_Request;
                itemValues.Add($"{request.RequestAsSent.Method.Method} - {request.RequestAsSent.RequestUri.AbsolutePath}");
                itemValues.Add(((int)request.response.StatusCode).ToString());
                itemValues.Add(request.response.StatusCode.ToString());
                itemValues.Add(request.ResponseTime.TotalSeconds.ToString("N2"));
                itemValues.Add(request.responseBody.Length.ToString("D"));
            }
            else if(item.objectItemType == WebTestResultItemType.Wtri_CommentItem)
            {
                var comment = item as WTRI_Comment;
                itemValues.Add(comment.CommentText);
                itemValues.Add("");
                itemValues.Add("");
                itemValues.Add("");
                itemValues.Add("");
            }
            else if (item.objectItemType == WebTestResultItemType.Wtri_IncludedWebTestItem)
            {
                itemValues.Add("Included Webtest Not yet implemented");
                itemValues.Add("");
                itemValues.Add("");
                itemValues.Add("");
                itemValues.Add("");
            }
            else if (item.objectItemType == WebTestResultItemType.Wtri_LoopControlItem)
            {
                var loop = item as WTRI_LoopControl;
                itemValues.Add("Loop Control");
                itemValues.Add(loop.ItemResult);
                //itemValues.Add(loop.totalElapsedTime.TotalSeconds.ToString("N2"));
                itemValues.Add("");
                itemValues.Add("");
                itemValues.Add("");
            }
            else if (item.objectItemType == WebTestResultItemType.Wtri_SkippedItem)
            {
                var skipped = item as WTRI_SkippedItem;
                itemValues.Add($"SKIPPED {skipped.webTestItemId}");
                itemValues.Add("");
                itemValues.Add("");
                itemValues.Add("");
                itemValues.Add("");
            }
            else if (item.objectItemType == WebTestResultItemType.Wtri_TransactionItem)
            {
                var loop = item as WTRI_Transaction;
                itemValues.Add("Transaction");
                itemValues.Add(loop.ItemResult);
                //itemValues.Add(loop.totalElapsedTime.TotalSeconds.ToString("N2"));
                itemValues.Add("");
                itemValues.Add("");
                itemValues.Add("");
            }
            else if (item.objectItemType == WebTestResultItemType.Wtri_LoopControlIteration)
            {
                var loop = item as WTRI_LoopControlIteration;
                itemValues.Add(loop.LoopIterationName);
                itemValues.Add(loop.ItemResult);
                //itemValues.Add(loop.totalElapsedTime.TotalSeconds.ToString("N2"));
                itemValues.Add("");
                itemValues.Add("");
                itemValues.Add("");
            }
            return itemValues;
        }

        private void RecurseTheWebTestResultsItemCollection(WebTestResultsItemCollection items, TreeViewItem parentTreeViewItem)
        {
            _treeCurrentDepth++;
            for (int nIndex = 0; nIndex < items.Count; nIndex++)
            {
                TreeViewItem treeItem = new TreeViewItem();
                treeItem.Name = parentTreeViewItem.Name + "_" + nIndex.ToString();

                #region === Request object ==============================
                if (items[nIndex] is WTRI_Request)
                {
                    parentTreeViewItem.Items.Add(ProcessRequestResultsItem(items[nIndex], parentTreeViewItem, nIndex));
                }
                #endregion

                #region === Comment =====================================
                else if (items[nIndex] is WTRI_Comment)
                {
                    WTRI_Comment cmt = items[nIndex] as WTRI_Comment;
                    treeItem.Header = CustomizeResultsTreeViewItem(cmt, (BitmapImage)Properties.Resources.Comment_24.ToWpfBitmap());
                    parentTreeViewItem.Items.Add(treeItem);
                }
                #endregion

                #region === Transaction Timer ===========================
                else if (items[nIndex] is WTRI_Transaction)
                {
                    WTRI_Transaction transaction = items[nIndex] as WTRI_Transaction;
                    treeItem.Header = CustomizeResultsTreeViewItem(transaction, (BitmapImage)Properties.Resources.TransactionTimer_24.ToWpfBitmap());
                    treeItem.IsExpanded = true;
                    parentTreeViewItem.Items.Add(treeItem);
                    RecurseTheWebTestResultsItemCollection(transaction.webTestResultsItems, treeItem);
                    _treeCurrentDepth--;
                }
                #endregion

                #region === Web Test Loop ===============================
                else if (items[nIndex] is WTRI_LoopControl)
                {
                    WTRI_LoopControl loop = items[nIndex] as WTRI_LoopControl;
                    treeItem.Header = CustomizeResultsTreeViewItem(loop, (BitmapImage)Properties.Resources.WebTestLoop_24.ToWpfBitmap());
                    treeItem.IsExpanded = true;
                    parentTreeViewItem.Items.Add(treeItem);
                    int loopIndex = 0;
                    foreach(var result in loop.loopIterations)
                    {
                        var loopIteration = new WTRI_LoopControlIteration(new Guid());
                        loopIteration.LoopIterationName = $"Iteration {loopIndex}";
                        loopIteration.loopIterationResultsItems = loop.loopResultsItems.loopResultsItems[result];
                        ProcessLoopIteration(loopIteration, treeItem, loopIndex++);
                        _treeCurrentDepth--;
                    }
                }
                #endregion

                #region === Included Web Test ===========================
                else if (items[nIndex] is WTRI_IncludedWebTest)
                {
                    WTRI_IncludedWebTest _webTest = items[nIndex] as WTRI_IncludedWebTest;
                    treeItem.Header = CustomizeTreeViewItem(_webTest.httpWebTest.Name, (BitmapImage)Properties.Resources.WebTest_24.ToWpfBitmap());
                    parentTreeViewItem.Items.Add(treeItem);
                }
                #endregion

                #region === Unknown item type ===========================
                #endregion
            }
            return;
        }

        private void ProcessLoopIteration(WTRI_LoopControlIteration loopIteration, TreeViewItem parentTreeViewItem, int nIndex)
        {
            _treeCurrentDepth++;
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Name = parentTreeViewItem.Name + "_" + nIndex.ToString();
            treeItem.Header = CustomizeResultsTreeViewItem(loopIteration, (BitmapImage)Properties.Resources.TransactionTimer_24.ToWpfBitmap());
            treeItem.IsExpanded = true;
            parentTreeViewItem.Items.Add(treeItem);
            RecurseTheWebTestResultsItemCollection(loopIteration.loopIterationResultsItems, treeItem);
            _treeCurrentDepth--;
        }

        private TreeViewItem ProcessRequestResultsItem(WebTestResultsItem item, TreeViewItem parentTreeViewItem, int nIndex)
        {
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Name = parentTreeViewItem.Name + "_" + nIndex.ToString();

            WTRI_Request wtr = (WTRI_Request)item;
            treeItem.Header = CustomizeResultsTreeViewItem(item, (BitmapImage)Properties.Resources.WebRequest_24.ToWpfBitmap());
            AddRequestQueryParams(treeItem, wtr);
            treeItem.Tag = wtr;
            return treeItem;
        }

        private void AddRequestQueryParams(TreeViewItem parentItem, WTRI_Request wtr)
        {
            if (wtr.RequestAsSent.RequestUri.Query.Length == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Query Parameters", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "QueryParameters";
            parentItem.Items.Add(treeItem);

            string[] parms = wtr.RequestAsSent.RequestUri.Query.UrlDecode().Split("&", StringSplitOptions.RemoveEmptyEntries);

            int x = 0;
            foreach (var parm in parms)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("{0} = {1}", parm.GetLeftPart("="), parm.GetRightPart("="));
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.Resources.QueryStringParam_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_QueryParam, x++);

                // This line adds the main request's tre view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = parentItem.Name;
                treeItem.Items.Add(subItem);
            }
        }

        private void AddRequestLevelRules(TreeViewItem parentItem, WTRI_Request request)
        {

            //if (request.Rules.Count == 0)
            //    return;

            //TreeViewItem treeItem = new TreeViewItem();
            //treeItem.Header = CustomizeTreeViewItem("Rules", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            //treeItem.Name = "RequestLevelRules";
            //parentItem.Items.Add(treeItem);

            //int x = 0;
            //foreach (var rule in request.Rules)
            //{
            //    TreeViewItem subItem = new TreeViewItem();
            //    string ruleDisplayName;
            //    if (rule.RuleType == RuleType.RequestRule_Extraction)
            //    {
            //        string contextName = (rule as ExtractionRule).ContextName;
            //        ruleDisplayName = $"{rule.Name} to: {contextName.AddBraces()}";
            //    }
            //    else
            //    {
            //        ruleDisplayName = $"{rule.Name}";
            //    }
            //    subItem.Header = CustomizeTreeViewItem(ruleDisplayName, (BitmapImage)Properties.Resources.RequestPlugin_24.ToWpfBitmap());
            //    subItem.Name = String.Format("{0}{1}", TVI_Name_RequestRule, x++);

            //    // This line adds the main request's tre view name here so we can get the actual collection item if we make changes to the
            //    // item's properties
            //    subItem.Tag = parentItem.Name;
            //    treeItem.Items.Add(subItem);
            //}
        }
        #endregion

        #region -- Property Display Methods -----
        private void PopulateResultsPropertiesStack(Dictionary<string, object> props, double width, object webTestItem)
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
                stack.Children.Add(GetPropertyValueDisplayElement(item, width - 120, IsTypeDescriptor));
                stackProperties.Children.Add(stack);
            }
            stackProperties.Tag = webTestItem;
        }

        private UIElement GetResultsPropertyValueDisplayElement(object propertyItem, double width, bool IsTypeDescriptor = false)
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

            else if (propertyItem.GetType() == typeof(RuleProperty))
                return GetTextBox(((RuleProperty)propertyItem).Value, width);
            
            else if(propertyItem.GetType() == typeof(HttpContent))
                return GetTextBox(((HttpContent)propertyItem).ReadAsStringAsync().GetAwaiter().GetResult(), width);
            
            else if (propertyItem.GetType() == typeof(BaseRuleType) ||
                propertyItem.GetType() == typeof(ControlComparisonScope) ||
                propertyItem.GetType() == typeof(DataSourceCursorType) ||
                propertyItem.GetType() == typeof(DataSourceType) ||
                propertyItem.GetType() == typeof(RuleResult) ||
                propertyItem.GetType() == typeof(ComparisonType) ||
                propertyItem.GetType() == typeof(RuleType))
            {
                var uiElement = GetEnumView(propertyItem, width);
                uiElement.Tag = propertyItem;
                return uiElement;
            }
            else return GetGuidText("Undetermined Item Type", width);

        }
        #endregion
    }
}
