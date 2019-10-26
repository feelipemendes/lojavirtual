namespace MongoDB.Data.Settings
{
    public interface IDatabaseSettings
    {
        string ProdutoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
