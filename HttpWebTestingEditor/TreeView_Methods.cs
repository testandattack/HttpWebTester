using GTC.Extensions;
using HttpWebTesting.Collections;
using HttpWebTesting.CoreObjects;
using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;
using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HttpWebTestingEditor
{
    public partial class HttpWebTestEditor : Window
    {
        private const string TVI_Name_ContextParameter = "ContextParameter_";
        private const string TVI_Name_TestRule = "TestLevelRules_";
        private const string TVI_Name_RequestRule = "RequestLevelRules_";
        private const string TVI_Name_DataSource = "DataSources_";
        private const string TVI_Name_Headers = "Headers_";
        private const string TVI_Name_QueryParam = "QueryParam_";
        private const string TVI_Name_FormParam = "FormParam_";
        private const string TVI_Name_StringBody = "StringBody";
        private const string TVI_Name_RecordedResponse = "RecordedResponse_";

        #region -- Treeview Population Methods -----
        private void PopulateTreeView()
        {
            tvWebTest.Items.Clear();

            // Set the root WebTest Node
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem(_webTest.Name, (BitmapImage)Properties.ImageResource.WebTest_24.ToWpfBitmap());
            treeItem.Name = "Root";

            // Walk the webtest and add dependent items
            RecurseTheWebTestItemCollection(_webTest.WebTestItems, treeItem);

            //// Add the webtest collections to the tree
            AddDataSources(treeItem);
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
                    treeItem.Header = CustomizeTreeViewItem(cmt.CommentText, (BitmapImage)Properties.ImageResource.Comment_24.ToWpfBitmap());
                    parentTreeViewItem.Items.Add(treeItem);
                }
                #endregion

                #region === Transaction Timer ===========================
                else if (items[nIndex] is WTI_Transaction)
                {
                    WTI_Transaction transaction = items[nIndex] as WTI_Transaction;
                    treeItem.Header = CustomizeTreeViewItem(transaction.Name, (BitmapImage)Properties.ImageResource.TransactionTimer_24.ToWpfBitmap());
                    treeItem.IsExpanded = true;
                    parentTreeViewItem.Items.Add(treeItem);
                    RecurseTheWebTestItemCollection(transaction.webTestItems, treeItem);
                }
                #endregion

                #region === Web Test Loop ===============================
                else if (items[nIndex] is WTI_LoopControl)
                {
                    WTI_LoopControl loop = items[nIndex] as WTI_LoopControl;
                    treeItem.Header = CustomizeTreeViewItem(loop.GetLoopControlDisplayName(), (BitmapImage)Properties.ImageResource.WebTestLoop_24.ToWpfBitmap());
                    treeItem.IsExpanded = true;
                    parentTreeViewItem.Items.Add(treeItem);
                    RecurseTheWebTestItemCollection(loop.webTestItems, treeItem);
                }
                #endregion

                #region === Included Web Test ===========================
                else if (items[nIndex] is WTI_IncludedWebTest)
                {
                    WTI_IncludedWebTest _webTest = items[nIndex] as WTI_IncludedWebTest;
                    treeItem.Header = CustomizeTreeViewItem(_webTest.Name, (BitmapImage)Properties.ImageResource.WebTestCondition_24.ToWpfBitmap());
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
            string itemLabel = $"{wtr.Method.ToString().ToUpper()}  {wtr.RequestUri.UrlDecode()}";
            treeItem.Header = CustomizeTreeViewItem(itemLabel, (BitmapImage)Properties.ImageResource.WebRequest_24.ToWpfBitmap());
            AddRequestHeaders(treeItem, wtr);
            AddRequestQueryParams(treeItem, wtr);
            AddRequestBody(treeItem, wtr);
            AddRequestLevelRules(treeItem, wtr);
            AddRequest_RecordedResponseValue(treeItem, wtr);
            treeItem.Tag = wtr;
            return treeItem;
        }

        private void AddContextParameters(TreeViewItem parentItem)
        {
            if (_webTest.ContextProperties.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Context Parameters", (BitmapImage)Properties.ImageResource.Folder_24.ToWpfBitmap());
            treeItem.Name = "ContextParameters";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (Property param in _webTest.ContextProperties)
            {
                string str;
                if ((string)param.Value == string.Empty && param.IsPassword)
                {
                    // Found a password that has not been assigned a value. Most likely this 
                    // is due to reading the test from a file. Passwords are not serialized in the files.
                    str = String.Format("{0} = {1}", param.Name, "Password value is currently not set to anything.");
                }
                else
                    str = String.Format("{0} = {1}", param.Name, param.Value);

                TreeViewItem subItem = new TreeViewItem();
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.ImageResource.ContextParameter_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_ContextParameter, x++);
                treeItem.Items.Add(subItem);
            }
        }

        private void AddRequestHeaders(TreeViewItem parentItem, WTI_Request request)
        {

            if (request.Headers.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Headers", (BitmapImage)Properties.ImageResource.Folder_24.ToWpfBitmap());
            treeItem.Name = "RequestHeaders";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var header in request.Headers)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("{0} = {1}", header.Key, header.Value.ToString(";"));
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.ImageResource.Header_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_Headers, x++);

                // This line adds the main request's tre view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = parentItem.Name;
                treeItem.Items.Add(subItem);
            }
        }

        private void AddRequestQueryParams(TreeViewItem parentItem, WTI_Request request)
        {

            if (request.QueryCollection.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Query Parameters", (BitmapImage)Properties.ImageResource.Folder_24.ToWpfBitmap());
            treeItem.Name = "QueryParameters";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var parm in request.QueryCollection.queryParams)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("{0} = {1}", parm.Key, parm.Value);
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.ImageResource.QueryStringParam_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_QueryParam, x++);

                // This line adds the main request's tree view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = parentItem.Name;
                treeItem.Items.Add(subItem);
            }
        }

        private void AddRequestBody(TreeViewItem parentItem, WTI_Request request)
        {
            if (request.Content == null)
                return;

            if (request.Content.GetType() == typeof(FormUrlEncodedContent))
                AddRequestFormPostParams(parentItem, request);
            else if (request.Content.GetType() == typeof(StringContent))
                AddRequestStringBody(parentItem, request);
        }

        private void AddRequestStringBody(TreeViewItem parentItem, WTI_Request request)
        {
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("String Body", (BitmapImage)Properties.ImageResource.StringBody_24.ToWpfBitmap());
            treeItem.Name = TVI_Name_StringBody;
            parentItem.Items.Add(treeItem);
        }

        private void AddRequestFormPostParams(TreeViewItem parentItem, WTI_Request request)
        {
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Form Post Parameters", (BitmapImage)Properties.ImageResource.Folder_24.ToWpfBitmap());
            treeItem.Name = "FormPostParameters";
            parentItem.Items.Add(treeItem);

            int x = 0;
            var parmCollection = request.FormPostParams;
            foreach (var parm in parmCollection)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("{0} = {1}", parm.Key, parm.Value);
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.ImageResource.FormPostParam_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_FormParam, x++);

                // This line adds the main request's tree view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = parentItem.Name;
                treeItem.Items.Add(subItem);
            }
        }

        private void AddRequest_RecordedResponseValue(TreeViewItem parentItem, WTI_Request request)
        {
            if (String.IsNullOrEmpty(request.RecordedResponseBody) == true)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            
            if(request.RecordedResponseBody.StartsWith("Request resulted in a redirect"))
                treeItem.Header = CustomizeTreeViewItem("Response was redirect", (BitmapImage)Properties.ImageResource.Redirect_24.ToWpfBitmap());
            else
                treeItem.Header = CustomizeTreeViewItem("Recorded Response Body", (BitmapImage)Properties.ImageResource.Response_24.ToWpfBitmap());

            treeItem.Name = TVI_Name_RecordedResponse;
            parentItem.Items.Add(treeItem);
        }

        private void AddRequestLevelRules(TreeViewItem parentItem, WTI_Request request)
        {

            if (request.Rules.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Rules", (BitmapImage)Properties.ImageResource.Folder_24.ToWpfBitmap());
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
                subItem.Header = CustomizeTreeViewItem(ruleDisplayName, (BitmapImage)Properties.ImageResource.RequestPlugin_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_RequestRule, x++);

                // This line adds the main request's tre view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = parentItem.Name;
                treeItem.Items.Add(subItem);
            }
        }

        private void AddTestLevelRules(TreeViewItem parentItem)
        {

            if (_webTest.Rules.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Rules", (BitmapImage)Properties.ImageResource.Folder_24.ToWpfBitmap());
            treeItem.Name = "TestLevelRules";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var rule in _webTest.Rules)
            {
                TreeViewItem subItem = new TreeViewItem();
                subItem.Header = CustomizeTreeViewItem(rule.Name, (BitmapImage)Properties.ImageResource.RequestPlugin_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_TestRule, x++);
                treeItem.Items.Add(subItem);
            }
        }

        private void AddDataSources(TreeViewItem parentItem)
        {
            if (_webTest.DataSources.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Data Sources", (BitmapImage)Properties.ImageResource.DataSources_24.ToWpfBitmap());
            treeItem.Name = "DataSources";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var dataSource in _webTest.DataSources)
            {
                TreeViewItem subItem = new TreeViewItem();
                subItem.Header = CustomizeTreeViewItem(dataSource.Name, (BitmapImage)Properties.ImageResource.DataSource_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_DataSource, x++);
                treeItem.Items.Add(subItem);
            }
        }
        #endregion
    }

    public class tvStackPanel : StackPanel
    {
        public int TreeViewItemId { get; set; }

    }
}
