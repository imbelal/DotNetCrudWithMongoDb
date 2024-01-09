using MongoDB.Driver;

namespace DotNetCrudWithMongoDb.Context
{
    public interface IApplicationDbContext
    {
        IMongoCollection<T> GetMongoDbCollection<T>(string collectionName) where T : class;
    }
}
