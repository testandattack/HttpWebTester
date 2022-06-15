namespace SharedResources
{
    public interface ISwaggerParser
    {
        public void PopulateApiDocument();
        public void PopulateApiDocument(string location);

        public void SaveOriginalSwaggerDocument();
        public void CreateAndSaveDtoCode();
        public void CreateAndSaveDtoCode(string fileName);
    }
}
