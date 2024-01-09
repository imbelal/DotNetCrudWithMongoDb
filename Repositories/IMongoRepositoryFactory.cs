namespace DotNetCrudWithMongoDb.Repositories;
public interface IMongoRepositoryFactory
{
    IMongoRepository<T> CreateRepository<T>(string collectionName) where T : class;
}
