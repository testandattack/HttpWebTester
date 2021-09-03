using HttpWebTesting;
using HttpWebTesting.DataSources;
using HttpWebTesting.Enums;
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
            foreach (var dataSource in httpWebTest.DataSources)
            {
                if(dataSource.dataSourceType == DataSourceType.CSV)
                {
                    dataSource.dataTable = CsvDataSourceLoader.LoadDataSource(((CsvDataSource)dataSource).csvDataSourceFile);
                } 
            }
        }

        private void BindDataSources()
        {
            foreach (var dataSource in httpWebTest.DataSources)
            {
                dataSource.GetNextRow(httpWebTest.ContextProperties);
            }
        }
    }
}
