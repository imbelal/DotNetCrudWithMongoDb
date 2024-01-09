using DotNetCrudWithMongoDb.Context;

namespace DotNetCrudWithMongoDb.Repositories;
public class MongoRepositoryFactory : IMongoRepositoryFactory
{
    private readonly IApplicationDbContext _context;

    public MongoRepositoryFactory(IApplicationDbContext context)
    {
        _context = context;
    }

    public IMongoRepository<T> CreateRepository<T>(string collectionName) where T : class
    {
        return new MongoRepository<T>(_context, collectionName);
    }
}