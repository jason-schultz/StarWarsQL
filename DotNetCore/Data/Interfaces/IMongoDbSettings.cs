namespace StartWarsQL.DotNetCore.Data.Interfaces
{
    public interface IMongoDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName {get; set;}
    }
}