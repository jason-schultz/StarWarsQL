using StartWarsQL.DotNetCore.Data.Interfaces;

namespace StartWarsQL.DotNetCore.Data
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}