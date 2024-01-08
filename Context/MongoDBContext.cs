using DotNetCrudWithMongoDb.Models;
using MongoDB.Driver;

namespace DotNetCrudWithMongoDb.Context
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Book> Books => _database.GetCollection<Book>("Books");
    }
}
