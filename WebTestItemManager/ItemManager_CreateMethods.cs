using HttpWebTesting;
using HttpWebTesting.Collections;
using HttpWebTesting.Enums;
using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WebTestItemManager
{
    public partial class ItemManager
    {
        #region -- Request Creation -----
        public static WTI_Request CreateNewRequest()
        {
            return CreateNewRequest(new HttpRequestMessage());
        }

        public static WTI_Request CreateNewRequest(string requestUri)
        {
            return CreateNewRequest(requestUri, HttpMethod.Get, new Version(1, 1));
        }

        public static WTI_Request CreateNewRequest(string requestUri, HttpMethod method)
        {
            return CreateNewRequest(requestUri, method, new Version(1, 1));
        }

        public static WTI_Request CreateNewRequest(string requestUri, HttpMethod method, HttpRequestHeaders Headers)
        {
            return CreateNewRequest(requestUri, method, Headers, new Version(1, 1));
        }

        public static WTI_Request CreateNewRequest(string requestUri, HttpMethod method, Version version)
        {

            HttpRequestMessage message = new HttpRequestMessage(method, requestUri);
            message.Version = version;

            WTI_Request request = new WTI_Request(message);

            return request;
        }

        public static WTI_Request CreateNewRequest(string requestUri, HttpMethod method, HttpRequestHeaders Headers, Version version)
        {
            
            HttpRequestMessage message = new HttpRequestMessage(method, requestUri);
            foreach(var header in Headers)
            {
                message.Headers.Add(header.Key, header.Value);
            }
            message.Version = version;

            WTI_Request request = new WTI_Request(message);

            return request;
        }

        public static WTI_Request CreateNewRequest(HttpRequestMessage message)
        {
            WTI_Request request = new WTI_Request(message);

            return request;
        }

        public static WTI_Request CreateNewJsonPostRequest(string requestUri, string content)
        {
            WTI_Request request = CreateNewRequest(requestUri, HttpMethod.Post);
            request.requestItem.Content = new StringContent(content, Encoding.UTF8, "application/json");
            return request;
        }

        public static WTI_Request CreateNewJsonPutRequest(string requestUri, string content)
        {
            WTI_Request request = CreateNewRequest(requestUri, HttpMethod.Put);
            request.requestItem.Content = new StringContent(content, Encoding.UTF8, "application/json");
            return request;
        }
        #endregion

        #region -- Trasaction Creation -----
        public static WTI_Transaction CreateNewTransaction()
        {
            return CreateNewTransaction("", "", new WebTestItemCollection());
        }

        public static WTI_Transaction CreateNewTransaction(string Name)
        {
            return CreateNewTransaction(Name, "", new WebTestItemCollection());
        }

        public static WTI_Transaction CreateNewTransaction(string Name, string Description)
        {
            return CreateNewTransaction(Name, Description, new WebTestItemCollection());
        }

        public static WTI_Transaction CreateNewTransaction(string Name, string Description, WebTestItemCollection items)
        {
            WTI_Transaction transaction = new WTI_Transaction();
            transaction.Name = Name;
            transaction.Description = Description;
            transaction.webTestItems = items;
            return transaction;
        }
        #endregion

        #region -- Loop Creation -----
        public static WTI_LoopControl CreateNew_FOR_LoopControl(int LoopStartingValue, int LoopEndingValue, int LoopIncrementValue)
        {
            return CreateNew_FOR_LoopControl(LoopStartingValue, LoopEndingValue, LoopIncrementValue, false, new WebTestItemCollection());
        }

        public static WTI_LoopControl CreateNew_FOR_LoopControl(int LoopStartingValue, int LoopEndingValue, int LoopIncrementValue, bool advanceDataCursor)
        {
            return CreateNew_FOR_LoopControl(LoopStartingValue, LoopEndingValue, LoopIncrementValue, advanceDataCursor, new WebTestItemCollection());
        }

        public static WTI_LoopControl CreateNew_FOR_LoopControl(int LoopStartingValue, int LoopEndingValue, int LoopIncrementValue, bool advanceDataCursor, WebTestItemCollection items)
        {
            WTI_LoopControl loop = new WTI_LoopControl();
            loop.ControlComparisonType = ComparisonType.IsLoop;
            loop.LoopStartingValue = LoopStartingValue;
            loop.LoopEndingValue = LoopEndingValue;
            loop.LoopIncrementValue = LoopIncrementValue;
            loop.AdvanceDataSourceOnEachIteration = advanceDataCursor;
            loop.webTestItems = items;
            return loop;
        }

        public static WTI_LoopControl CreateNew_IF_LoopControl(RuleProperty firstOperand, ComparisonType type, RuleProperty secondOperand)
        {
            return CreateNew_IF_LoopControl(firstOperand, type, secondOperand, false, false, new WebTestItemCollection());
        }

        public static WTI_LoopControl CreateNew_IF_LoopControl(RuleProperty firstOperand, ComparisonType type, RuleProperty secondOperand, bool ignoreCase, bool advanceDataCursor)
        {
            return CreateNew_IF_LoopControl(firstOperand, type, secondOperand, ignoreCase, advanceDataCursor, new WebTestItemCollection());
        }

        public static WTI_LoopControl CreateNew_IF_LoopControl(RuleProperty firstOperand, ComparisonType type, RuleProperty secondOperand, bool ignoreCase, bool advanceDataCursor, WebTestItemCollection items)
        {
            WTI_LoopControl loop = new WTI_LoopControl();
            loop.ControlComparisonScope = ControlComparisonScope.If;
            loop.FirstOperand = firstOperand;
            loop.ControlComparisonType = type;
            loop.SecondOperand = secondOperand;
            loop.IgnoreCase = ignoreCase;
            loop.AdvanceDataSourceOnEachIteration = advanceDataCursor;
            loop.webTestItems = items;
            return loop;
        }

        public static WTI_LoopControl CreateNew_WHILE_LoopControl(RuleProperty firstOperand, ComparisonType type, RuleProperty secondOperand)
        {
            return CreateNew_WHILE_LoopControl(firstOperand, type, secondOperand, false, false, new WebTestItemCollection());
        }

        public static WTI_LoopControl CreateNew_WHILE_LoopControl(RuleProperty firstOperand, ComparisonType type, RuleProperty secondOperand, bool ignoreCase, bool advanceDataCursor)
        {
            return CreateNew_WHILE_LoopControl(firstOperand, type, secondOperand, ignoreCase, advanceDataCursor, new WebTestItemCollection());
        }

        public static WTI_LoopControl CreateNew_WHILE_LoopControl(RuleProperty firstOperand, ComparisonType type, RuleProperty secondOperand, bool ignoreCase, bool advanceDataCursor, WebTestItemCollection items)
        {
            WTI_LoopControl loop = new WTI_LoopControl();
            loop.ControlComparisonScope = ControlComparisonScope.While;
            loop.FirstOperand = firstOperand;
            loop.ControlComparisonType = type;
            loop.SecondOperand = secondOperand;
            loop.IgnoreCase = ignoreCase;
            loop.AdvanceDataSourceOnEachIteration = advanceDataCursor;
            loop.webTestItems = items;
            return loop;
        }
        #endregion
    }
}
