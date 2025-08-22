namespace LicencaMongoDB.Model
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string LicencaCollectionName { get; set; } = "Licenca";

    }
}
