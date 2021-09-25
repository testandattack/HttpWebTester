using HttpWebTesting.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using GTC.Extensions;
using System.Linq;

namespace HttpWebTesting.DataSources
{
    public class CsvDataSource : BaseDataSource
    {
        public string csvDataSourceFile { get; set; }

        public CsvDataSource() 
        {
            dataSourceType = DataSourceType.CSV;
        }

        #region -- implementations for the base class requirements -----
        private CsvDataSource(CsvDataSource copy) : base(copy) { }

        public override object Clone()
        {
            return new CsvDataSource(this);
        }
        #endregion
    }
}
