using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTesting.DataSources
{
    public class AdoDataSource : BaseDataSource
    {
        private AdoDataSource(AdoDataSource copy) : base(copy) { }

        public override object Clone()
        {
            return new AdoDataSource(this);
        }

        public AdoDataSource() { }
    }
}
