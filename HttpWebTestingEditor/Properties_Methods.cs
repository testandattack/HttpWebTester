using GTC.Extensions;
using HttpWebTesting.CoreObjects;
using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace HttpWebTestingEditor
{
    public partial class HttpWebTestEditor : Window
    {

        private Dictionary<string, object> GetWebTestItemProperties(WebTestItem item)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();

            WebTestItem webTestItem;
            switch (item.objectItemType)
            {
                case WebTestItemType.Wti_Comment:
                    webTestItem = item as WTI_Comment;
                    break;
                case WebTestItemType.Wti_IncludedWebTestItem:
                    webTestItem = item as WTI_IncludedWebTest;
                    break;
                case WebTestItemType.Wti_LoopControl:
                    webTestItem = item as WTI_LoopControl;
                    break;
                case WebTestItemType.Wti_RequestObject:
                    webTestItem = item as WTI_Request;
                    break;
                case WebTestItemType.Wti_Transactiontimer:
                    webTestItem = item as WTI_Transaction;
                    break;
                default:
                    return properties;
            }


            foreach (var prop in webTestItem.GetType().GetProperties())
            {
                var propValue = prop.GetValue(webTestItem, null);
                if (propValue != null)
                    properties.Add(prop.Name, propValue);
                else
                    properties.Add(prop.Name, "null");
            }
            return properties;

        }

        private Dictionary<string, object> GetTestLevelItemProperties(object item)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();

            foreach (var prop in item.GetType().GetProperties())
            {
                var propValue = prop.GetValue(item, null);
                if (propValue != null)
                    properties.Add(prop.Name, propValue);
                else
                    properties.Add(prop.Name, "null");
            }
            return properties;

        }

        #region -- Property Display Methods -----
        private void PopulatePropertiesStack(Dictionary<string, object> props, double width, object parenttem)
        {
            foreach (var item in props)
            {
                TextBlock block = new TextBlock();
                block.Text = item.Key;
                block.Width = 100;

                StackPanel stack = new StackPanel();
                stack.Orientation = Orientation.Horizontal;
                stack.Margin = new Thickness(3);

                bool IsTypeDescriptor = (item.Key == "Type") ? true : false;
                stack.Children.Add(block);
                var uiElement = GetPropertyValueDisplayElement(item, width - 120, IsTypeDescriptor);
                stack.Children.Add(uiElement);
                stackProperties.Children.Add(stack);
            }
            stackProperties.Tag = parenttem;
        }

        private UIElement GetPropertyValueDisplayElement(KeyValuePair<string, object> propertyItem, double width, bool IsTypeDescriptor = false)
        {
            if (IsTypeDescriptor == true)
            {
                TextBlock uiElement = GetGuidText(propertyItem.Value.ToString(), width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.Value.GetType() == typeof(System.String))
            {
                var uiElement = GetTextBox(propertyItem.Value, width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.Value.GetType() == typeof(System.Net.Http.HttpMethod))
            {
                var uiElement = GetTextBox(((HttpMethod)propertyItem.Value).Method, width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.Value.GetType() == typeof(System.Uri))
            {
                var uiElement = GetTextBox(((Uri)propertyItem.Value).AbsoluteUri.UrlDecode(), width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.Value.GetType() == typeof(System.Guid))
            {
                var uiElement = GetGuidText(propertyItem.Value.ToString(), width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.Value.GetType() == typeof(System.Boolean))
            {
                var uiElement = GetCheckBox(propertyItem.Value, width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.Value.GetType() == typeof(System.Int32) ||
                propertyItem.Value.GetType() == typeof(System.Double) ||
                propertyItem.Value.GetType() == typeof(System.Decimal) ||
                propertyItem.Value.GetType() == typeof(System.Single))
            {
                var uiElement = GetNumberTextBox(propertyItem, width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.Value.GetType().GetInterface(nameof(ICollection)) != null)
            {
                var uiElement = GetCollectionView(propertyItem.Value, width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.Value.GetType() == typeof(RuleProperty))
            {
                var uiElement = GetTextBox(((RuleProperty)propertyItem.Value).Value, width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.Value.GetType() == typeof(Property))
            {
                var uiElement = GetTextBox(((Property)propertyItem.Value).Value, width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.Value.GetType() == typeof(HttpContent))
            {
                var uiElement = GetTextBox(((HttpContent)propertyItem.Value).ReadAsStringAsync().GetAwaiter().GetResult(), width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.Value.GetType() == typeof(WebTestItemType))
            {
                var uiElement = GetGuidText(propertyItem.Value.ToString(), width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else if (propertyItem.GetType() == typeof(BaseRuleType) ||
                propertyItem.GetType() == typeof(ControlComparisonScope) ||
                propertyItem.GetType() == typeof(DataSourceCursorType) ||
                propertyItem.GetType() == typeof(DataSourceType) ||
                propertyItem.GetType() == typeof(RuleResult) ||
                propertyItem.GetType() == typeof(ComparisonType) ||
                propertyItem.GetType() == typeof(RuleType))
            {
                var uiElement = GetEnumView(propertyItem.Value, width);
                uiElement.Tag = propertyItem.Value;
                return uiElement;
            }
            else return GetGuidText("Undetermined Item Type", width);
        }

        private TextBox GetTextBox(object propertyItem, double width)
        {
            TextBox box = new TextBox();
            box.Text = propertyItem == null ? "" : (string)propertyItem;
            box.Width = width;
            return box;
        }

        private CheckBox GetCheckBox(object propertyItem, double width)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.IsChecked = (bool)propertyItem;
            return checkBox;
        }

        private TextBox GetNumberTextBox(object propertyItem, double width)
        {
            TextBox box = new TextBox();
            box.Text = propertyItem == null ? "" : propertyItem.ToString();
            box.MinWidth = 50;
            return box;
        }

        private TextBlock GetGuidText(object propertyItem, double width)
        {
            TextBlock box = new TextBlock();
            box.Text = propertyItem == null ? "" : propertyItem.ToString();
            return box;
        }

        private ListBox GetCollectionView(object propertyItem, double width)
        {
            ListBox listBox = new ListBox();
            foreach (var item in (ICollection)propertyItem)
            {
                ListBoxItem newItem = new ListBoxItem();
                newItem.Content = item == null ? "" : item;
                listBox.Items.Add(newItem);
            }
            listBox.Width = width;
            listBox.IsEnabled = false;
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

        private ComboBox GetEnumView(object propertyItem, double width)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.IsEditable = false;
            var enumNames = Enum.GetNames((propertyItem.GetType()));
            foreach (string item in enumNames)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = item == null ? "" : item;
                if (item == propertyItem.ToString())
                    newItem.IsSelected = true;
                comboBox.Items.Add(newItem);
            }
            comboBox.Width = width;

            comboBox.SelectedItem = propertyItem.ToString();
            return comboBox;
        }
        #endregion

        // This code calls the below method and stores info in the data table below
        //var displayInfo = new PropertyDisplayInfoCollection();
        //displayInfo.AddAllItems(webTestItem, webTestItem.objectItemType.ToString());
        //AddDisplayInfoData(displayInfo);


        //private void AddDisplayInfoData(PropertyDisplayInfoCollection displayInfo)
        //{
        //    _propertiesDataTable.Rows.Clear();
        //    foreach (var displayItem in displayInfo)
        //    {
        //        string sDefaultValue;
        //        if (displayItem.DefaultValue == null)
        //            sDefaultValue = "null";
        //        else
        //            sDefaultValue = displayItem.DefaultValue.ToString();

        //        _propertiesDataTable.Rows.Add(
        //            displayItem.Browsable,
        //            displayItem.JsonIgnore,
        //            displayItem.DisplayName,
        //            displayItem.Description,
        //            displayItem.Category,
        //            sDefaultValue,
        //            displayItem.type.Name);
        //    }
        //}
        //private void CreatePropertiesDataTable()
        //{
        //    _propertiesDataTable = new System.Data.DataTable();
        //    _propertiesDataTable.Columns.Add(new DataColumn("Browsable", typeof(System.Boolean)));
        //    _propertiesDataTable.Columns.Add(new DataColumn("JsonIgnore", typeof(System.Boolean)));
        //    _propertiesDataTable.Columns.Add(new DataColumn("DisplayName", typeof(System.String)));
        //    _propertiesDataTable.Columns.Add(new DataColumn("Description", typeof(System.String)));
        //    _propertiesDataTable.Columns.Add(new DataColumn("Category", typeof(System.String)));
        //    _propertiesDataTable.Columns.Add(new DataColumn("DefaultValue", typeof(System.String)));
        //    _propertiesDataTable.Columns.Add(new DataColumn("Type", typeof(System.String)));
        //}
    }
}
