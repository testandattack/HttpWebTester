using ApiTestGenerator.Models.ApiDocs;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HttpWebTestingEditor
{
    public partial class HttpWebTestEditor : Window
    {
        private const string TVI_Name_Controllers = "Controllers_";
        private const string TVI_Name_Endpoints = "Endpoints_";
        private const string TVI_Name_Servers = "Servers_";
        private const string TVI_Name_EndpointParams = "EndpointParams_";
        private const string TVI_Name_Responses = "Responses_";
        private const string TVI_Name_Components = "Components_";
        private const string TVI_Name_Properties = "Properties_";

        #region -- Treeview Population Methods -----
        private void PopulateAPITreeView(ApiSet apiSet)
        {
            tvAPI.Items.Clear();

            // Set the root WebTest Node
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem(apiSet.Info.Title, (BitmapImage)Properties.Resources.WebRequest_24.ToWpfBitmap());
            treeItem.Name = "Root";

            AddServerSet(apiSet.Servers, treeItem);
            ProcessController_Endoint_Sets(apiSet.Controllers, treeItem);
            ProcessOpenApiComponents(apiSet.Components, treeItem);

            //Add the entire list to the tree 
            tvAPI.Items.Add(treeItem);

            // expand tree to the first level
            treeItem.IsExpanded = true;
        }

        private StackPanel CustomizeApiTreeViewItem(object itemObj, BitmapImage bmi, int tvItemId = 0)
        {
            return CustomizeTreeViewItem(itemObj, bmi, Colors.White, tvItemId);
        }

        private StackPanel CustomizeApiTreeViewItem(object itemObj, BitmapImage bmi, System.Windows.Media.Color color, int tvItemId = 0)
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

        private void AddServerSet(List<OpenApiServer> servers, TreeViewItem parentItem)
        {
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Servers", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "Servers";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var server in servers)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("Url = {0}", server.Url );
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.Resources.Header_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_Servers, x++);

                // This line adds the main request's tre view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = parentItem.Name;
                treeItem.Items.Add(subItem);
            }
        }

        private void ProcessController_Endoint_Sets(Dictionary<string, Controller> controllers, TreeViewItem parentTreeViewItem)
        {
            if(controllers.Count == 1)
            {
                if(controllers.First().Key == "")
                {
                    ProcessOpenApiEndpointItems(controllers.First().Value.EndPoints, parentTreeViewItem);
                }
            }
            else
            {
                ProcessOpenApiControllerItems(controllers, parentTreeViewItem);
            }
        }

        private void ProcessOpenApiControllerItems(Dictionary<string, Controller> controllers, TreeViewItem parentTreeViewItem)
        {
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Controllers", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "Controllers";
            parentTreeViewItem.Items.Add(treeItem);


            int x = 0;
            foreach (var controller in controllers)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("Name = {0}", controller.Key == "" ? "<unnamed>" : controller.Key);
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.Resources.Header_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_Controllers, x++);
                ProcessOpenApiEndpointItems(controller.Value.EndPoints, subItem);
                
                // This line adds the main request's tre view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = parentTreeViewItem.Name;
                treeItem.Items.Add(subItem);
            }
        }

        private void ProcessOpenApiEndpointItems(Dictionary<string, EndPoint> endpoints, TreeViewItem parentTreeViewItem)
        {
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Endpoints", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "Endpoints";
            parentTreeViewItem.Items.Add(treeItem);


            int x = 0;
            foreach (var endpoint in endpoints)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("Name = {0}", endpoint.Key == "" ? "<unnamed>" : endpoint.Key);
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.Resources.Header_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_Endpoints, x++);
                AddEndpointParameters(subItem, endpoint.Value);
                AddEndpointResponses(subItem, endpoint.Value);

                // This line adds the main request's tre view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = endpoint;
                treeItem.Items.Add(subItem);
            }
        }

        private void ProcessOpenApiComponents(Dictionary<string, Component> components, TreeViewItem parentTreeViewItem)
        {
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Components", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "Components";
            parentTreeViewItem.Items.Add(treeItem);


            int x = 0;
            foreach (var component in components)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("Name = {0}", component.Key == "" ? "<unnamed>" : component.Key);
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.Resources.Header_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_Components, x++);
                AddComponentProperties(subItem, component.Value);

                // This line adds the main request's tre view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = component;
                treeItem.Items.Add(subItem);
            }
        }

        private void AddEndpointParameters(TreeViewItem parentItem, EndPoint endPoint)
        {
            if (endPoint.parameters == null || endPoint.parameters.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Parameters", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "Parameters";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var parameter in endPoint.parameters)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("Name = {0}", parameter.Key);
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.Resources.QueryStringParam_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_EndpointParams, x++);

                // This line adds the main request's tre view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = parameter;
                treeItem.Items.Add(subItem);
            }
        }

        private void AddEndpointResponses(TreeViewItem parentItem, EndPoint endPoint)
        {
            if (endPoint.ResponseItems == null || endPoint.ResponseItems.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Responses", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "Responses";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var response in endPoint.ResponseItems)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("<Bold>Status Code: {0}</Bold>, Description = {1}", response.Key, response.Value.Description);
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.Resources.Response_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_Responses, x++);

                // This line adds the main request's tre view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = response;
                treeItem.Items.Add(subItem);
            }
        }

        private void AddComponentProperties(TreeViewItem parentItem, Component component)
        {
            //ApiTestGenerator.Models.ApiDocs.Property property
            if (component.properties == null || component.properties.Count == 0)
                return;

            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = CustomizeTreeViewItem("Properties", (BitmapImage)Properties.Resources.Folder_24.ToWpfBitmap());
            treeItem.Name = "Properties";
            parentItem.Items.Add(treeItem);

            int x = 0;
            foreach (var property in component.properties)
            {
                TreeViewItem subItem = new TreeViewItem();
                string str = String.Format("Name = {0}", property.Key);
                subItem.Header = CustomizeTreeViewItem(str, (BitmapImage)Properties.Resources.Header_24.ToWpfBitmap());
                subItem.Name = String.Format("{0}{1}", TVI_Name_Properties, x++);

                // This line adds the main request's tre view name here so we can get the actual collection item if we make changes to the
                // item's properties
                subItem.Tag = property;
                treeItem.Items.Add(subItem);
            }
        }
        #endregion
    }

}
