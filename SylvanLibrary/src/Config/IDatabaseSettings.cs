namespace SylvanLibrary.Config
{
    public interface IDatabaseSettings
    {
        string CollectionCollectionName { get; set; }
        string CardCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}