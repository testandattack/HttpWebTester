using HttpWebTesting;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebTestExecutionEngine
{

    public class LoopControlExecution
    {
        public HttpWebTest httpWebTest { get; set; }

        public WTI_LoopControl loopControl { get; set; }

        private StringComparison stringComp;

        #region -- Constructors -----
        public LoopControlExecution(WTI_LoopControl wTI_LoopControl, HttpWebTest webTest)
        {
            httpWebTest = webTest;
            loopControl = wTI_LoopControl;
            if (loopControl.IgnoreCase)
                stringComp = StringComparison.CurrentCultureIgnoreCase;
            else
                stringComp = StringComparison.CurrentCulture;
        }
        #endregion

        public async Task<WebTestResultsItem> ProcessLoopAsync()
        {
            if(loopControl.Enabled == false)
            {
                WTI_SkippedItem skippedItem = new WTI_SkippedItem(loopControl.Name, WebTestItemType.Wti_LoopControl);
                return new WTRI_SkippedItem(skippedItem);
            }

            WTRI_LoopControl loopControlResults = new WTRI_LoopControl(loopControl.guid);
            if (loopControl.ControlComparisonType == ComparisonType.IsLoop)
                loopControlResults.ItemExecutionFailed = !(await HandleLoopAsync(loopControlResults));
            else if (loopControl.ControlComparisonScope == ControlComparisonScope.While)
                loopControlResults.ItemExecutionFailed = !(await HandleMultiPassComparisonAsync(loopControlResults));
            else
                loopControlResults.ItemExecutionFailed = !(await HandleSinglePassComparisonAsync(loopControlResults));
            return loopControlResults;
        }

        #region -- Private Methods -----
        private async Task<bool> HandleLoopAsync(WTRI_LoopControl results)
        {
            int start = (int)loopControl.LoopStartingValue;
            int end = (int)loopControl.LoopEndingValue;
            int increment = (int)loopControl.LoopIncrementValue;

            for (int x = start; x < end; x += increment)
            {
                var passed = await ExecuteItemCollectionAsync(results, x);
                if (passed == false)
                    return false;
            }
            return true;
        }

        private async Task<bool> HandleMultiPassComparisonAsync(WTRI_LoopControl results)
        {
            int iterationNum = 1;
            while (PerformComparison() == true)
            {
                var passed = await ExecuteItemCollectionAsync(results, iterationNum++);
                if (passed == false)
                    return false;
            }
            return true;
        }

        private async Task<bool> HandleSinglePassComparisonAsync(WTRI_LoopControl results)
        {
            if(PerformComparison() == true)
            {
                return await ExecuteItemCollectionAsync(results, 1);
            }
            return true;
        }

        private async Task<bool> ExecuteItemCollectionAsync(WTRI_LoopControl results, int iterationId)
        {
            string iteration = $"Iteration {iterationId}";
            var result = await WebTestItemCollectionExecution.ExecuteWebTestItemCollectionAsync(httpWebTest, loopControl.webTestItems);
            results.loopResultsItems.Add(iteration, result);
            if (result.ExecutionState == RuleResult.Failed)
                return false;
            HandleDataSourceCursorAdvance();
            return true;
        }

        private bool PerformComparison()
        {
            switch (loopControl.ControlComparisonType)
            {
                // Normal String Comparisons here.
                case ComparisonType.Contains:
                    return loopControl.FirstOperand.Value.Contains(loopControl.SecondOperand.Value, stringComp);
                case ComparisonType.DoesNotContain:
                    return !loopControl.FirstOperand.Value.Contains(loopControl.SecondOperand.Value, stringComp);
                case ComparisonType.StartsWith:
                    return loopControl.FirstOperand.Value.StartsWith(loopControl.SecondOperand.Value, stringComp);
                case ComparisonType.EndsWith:
                    return loopControl.FirstOperand.Value.EndsWith(loopControl.SecondOperand.Value, stringComp);
                
                // Here we use the RuleProperty Comparer
                case ComparisonType.IsEqual:
                    if (loopControl.FirstOperand.CompareTo(loopControl.SecondOperand) == 0)
                        return true;
                    else
                        return false;
                case ComparisonType.IsGreaterThan:
                    if (loopControl.FirstOperand.CompareTo(loopControl.SecondOperand) == 1)
                        return true;
                    else
                        return false;
                case ComparisonType.IsGreaterThanOrEqual:
                    if (loopControl.FirstOperand.CompareTo(loopControl.SecondOperand) == 0
                        || loopControl.FirstOperand.CompareTo(loopControl.SecondOperand) == 1)
                        return true;
                    else
                        return false;
                case ComparisonType.IsLessThan:
                    if (loopControl.FirstOperand.CompareTo(loopControl.SecondOperand) == -1)
                        return true;
                    else
                        return false;
                case ComparisonType.IsLessThanOrEqual:
                    if (loopControl.FirstOperand.CompareTo(loopControl.SecondOperand) == 0
                        || loopControl.FirstOperand.CompareTo(loopControl.SecondOperand) == -1)
                        return true;
                    else
                        return false;
                case ComparisonType.IsNotEqual:
                    if (loopControl.FirstOperand.CompareTo(loopControl.SecondOperand) != 0)
                        return true;
                    else
                        return false;
                default:
                    break;
            }
            
            return false;
        }

        private void HandleDataSourceCursorAdvance()
        {
            if (loopControl.AdvanceDataSourceOnEachIteration)
            {
                foreach (var dataSource in httpWebTest.DataSources)
                {
                    dataSource.GetNextRow(httpWebTest.ContextProperties);
                }
            }
        }
        #endregion
    }
}
