using Newtonsoft.Json;
using HttpWebTesting.WebTestItems;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HttpWebTesting.Enums;

namespace HttpWebTestingResults
{

    public class WebTestResultsItemCollection : BaseCollection<WebTestResultsItem>
    {
        public WebTestResultsItemCollection() { }

        public RuleResult ExecutionState = RuleResult.NotEvaluatedYet;

        public new void Add(WebTestResultsItem resultsItem)
        {
            base.Add(resultsItem);
            if (resultsItem.ItemExecutionFailed == true)
                ExecutionState = RuleResult.Failed;
        }

        //public bool ContainsFailedItem()
        //{
        //    foreach(var item in this.Items)
        //    {
        //        if (item.ItemExecutionFailed == true)
                    
        //            return true;

        //        switch (item.objectItemType)
        //        {
        //            case WebTestResultItemType.Wtri_IncludedWebTestItem:
        //                if (SubListContainsFailedItem((item as WTRI_IncludedWebTest).webTestResultsItems) == true)
        //                {
        //                    ExecutionState = RuleResult.Failed;
        //                    return true;
        //                }
        //                break;
 
        //            case WebTestResultItemType.Wtri_TransactionItem:
        //                if (SubListContainsFailedItem((item as WTRI_Transaction).webTestResultsItems) == true)
        //                {
        //                    ExecutionState = RuleResult.Failed;
        //                    return true;
        //                }
        //                break;

        //            case WebTestResultItemType.Wtri_LoopControlItem:
        //                if (LoopListContainsFailedItem((item as WTRI_LoopControl).loopResultsItems) == true)
        //                {
        //                    ExecutionState = RuleResult.Failed;
        //                    return true;
        //                }
        //                break;
        //        }
        //    }
        //    return false;
        //}

        //private bool SubListContainsFailedItem(Collection<WebTestResultsItem> items)
        //{
        //    foreach (var item in items)
        //    {
        //        if (item.ItemExecutionFailed == true)
        //            return true;

        //        switch (item.objectItemType)
        //        {
        //            case WebTestResultItemType.Wtri_IncludedWebTestItem:
        //                if (SubListContainsFailedItem((item as WTRI_IncludedWebTest).webTestResultsItems) == true)
        //                    return true;
        //                break;

        //            case WebTestResultItemType.Wtri_TransactionItem:
        //                if (SubListContainsFailedItem((item as WTRI_Transaction).webTestResultsItems) == true)
        //                    return true;
        //                break;

        //            case WebTestResultItemType.Wtri_LoopControlItem:
        //                if (LoopListContainsFailedItem((item as WTRI_LoopControl).loopResultsItems) == true)
        //                    return true;
        //                break;
        //        }
        //    }
        //    return false;
        //}

        //private bool LoopListContainsFailedItem(LoopControlResultsItemCollection items)
        //{
        //    foreach (var itemSet in items.loopResultsItems)
        //    {
        //        foreach (var item in itemSet.Value)
        //        {
        //            if (item.ItemExecutionFailed == true)
        //                return true;

        //            switch (item.objectItemType)
        //            {
        //                case WebTestResultItemType.Wtri_IncludedWebTestItem:
        //                    if (SubListContainsFailedItem((item as WTRI_IncludedWebTest).webTestResultsItems) == true)
        //                        return true;
        //                    break;

        //                case WebTestResultItemType.Wtri_TransactionItem:
        //                    if (SubListContainsFailedItem((item as WTRI_Transaction).webTestResultsItems) == true)
        //                        return true;
        //                    break;

        //                case WebTestResultItemType.Wtri_LoopControlItem:
        //                    if (LoopListContainsFailedItem((item as WTRI_LoopControl).loopResultsItems) == true)
        //                        return true;
        //                    break;
        //            }
        //        }
        //    }
        //    return false;
        //}
    }
}
