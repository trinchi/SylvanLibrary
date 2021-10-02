namespace SylvanLibrary.Config
{
    public class SylvanLibraryDatabaseSettings: IDatabaseSettings
    {
        public string CollectionCollectionName { get; set; }
        public string CardCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}