using HttpWebTesting.DataSources;

namespace HttpWebTesting.Collections
{
    public class DataSourceCollection : BaseCollection<BaseDataSource>
    {
        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }
}
