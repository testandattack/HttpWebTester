using HttpWebTesting.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTesting.DataSources
{
    public class CsvDataSource : BaseDataSource
    {
        private CsvDataSource(CsvDataSource copy) : base(copy) { }

        public override object Clone()
        {
            return new CsvDataSource(this);
        }

        public CsvDataSource() 
        {
            dataSourceType = DataSourceType.CSV;
        }
    }
}
