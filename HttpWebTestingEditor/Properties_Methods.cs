﻿using HttpWebTesting.Collections;
using HttpWebTesting.CoreObjects;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Linq.Expressions;

namespace HttpWebTestingEditor
{
    public partial class HttpWebTestEditor : Window
    {
        private void CreatePropertiesDataTable()
        {
            _propertiesDataTable = new System.Data.DataTable();
            _propertiesDataTable.Columns.Add(new DataColumn("Browsable", typeof(System.Boolean)));
            _propertiesDataTable.Columns.Add(new DataColumn("JsonIgnore", typeof(System.Boolean)));
            _propertiesDataTable.Columns.Add(new DataColumn("DisplayName", typeof(System.String)));
            _propertiesDataTable.Columns.Add(new DataColumn("Description", typeof(System.String)));
            _propertiesDataTable.Columns.Add(new DataColumn("Category", typeof(System.String)));
            _propertiesDataTable.Columns.Add(new DataColumn("DefaultValue", typeof(System.String)));
            _propertiesDataTable.Columns.Add(new DataColumn("Type", typeof(System.String)));
        }

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

            //var displayInfo = new PropertyDisplayInfoCollection();
            //displayInfo.AddAllItems(webTestItem, webTestItem.objectItemType.ToString());
            //AddDisplayInfoData(displayInfo);

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

        private void AddDisplayInfoData(PropertyDisplayInfoCollection displayInfo)
        {
            _propertiesDataTable.Rows.Clear();
            foreach (var displayItem in displayInfo)
            {
                string sDefaultValue;
                if (displayItem.DefaultValue == null)
                    sDefaultValue = "null";
                else
                    sDefaultValue = displayItem.DefaultValue.ToString();

                _propertiesDataTable.Rows.Add(
                    displayItem.Browsable,
                    displayItem.JsonIgnore,
                    displayItem.DisplayName,
                    displayItem.Description,
                    displayItem.Category,
                    sDefaultValue,
                    displayItem.type.Name);
            }
        }
    }
 }
