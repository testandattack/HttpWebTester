using HttpWebTesting;
using HttpWebTesting.DataSources;
using HttpWebTesting.Enums;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestExecutionEngine
{
    public class PreWebTestExecution
    {
        public HttpWebTest httpWebTest { get; set; }

        public PreWebTestExecution() { }

        public void ProcessPreWebTest(HttpWebTest webTest)
        {
            httpWebTest = webTest;
            LoadDataSources();
            BindDataSources(); 
            // NOTE: Eventually we need to add code here for the 
            // PreWebTest event handlers
        }

        private void LoadDataSources()
        {
            Log.ForContext("SourceContext", "PreWebTestExecution").Debug("Executing {objectItemType}", "LoadDataSources");
            foreach (var dataSource in httpWebTest.DataSources)
            {
                if(dataSource.dataSourceType == DataSourceType.CSV)
                {
                    string fileLocation = string.Empty;
                    if (((CsvDataSource)dataSource).csvDataSourceFile.Contains("\\") == false)
                        fileLocation = httpWebTest.WorkingDirectoryLocation + "\\" + ((CsvDataSource)dataSource).csvDataSourceFile;
                    else
                        fileLocation = ((CsvDataSource)dataSource).csvDataSourceFile;

                    dataSource.dataTable = CsvDataSourceLoader.LoadDataSource(fileLocation);
                }
                Log.ForContext("SourceContext", "PreWebTestExecution").Debug("Loaded {objectItemType}", dataSource);
            }
        }

        private void BindDataSources()
        {
            Log.ForContext("SourceContext", "PreWebTestExecution").Debug("Executing {objectItemType}", "BindDataSources");
            foreach (var dataSource in httpWebTest.DataSources)
            {
                dataSource.GetNextRow(httpWebTest.ContextProperties);
            }
            Log.ForContext("SourceContext", "PreWebTestExecution").Debug("Bound all data sources.");
        }
    }
}
