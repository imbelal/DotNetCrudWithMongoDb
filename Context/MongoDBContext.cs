using MongoDB.Driver;

namespace DotNetCrudWithMongoDb.Context
{
    public class MongoDBContext : IApplicationDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetMongoDbCollection<T>(string collectionName) where T : class
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
