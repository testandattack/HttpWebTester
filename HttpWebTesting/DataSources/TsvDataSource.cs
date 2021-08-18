using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTesting.DataSources
{
    public class TsvDataSource : BaseDataSource
    {
        private TsvDataSource(TsvDataSource copy) : base(copy) { }

        public override object Clone()
        {
            return new TsvDataSource(this);
        }

        public TsvDataSource() { }
    }
}
