using DotNetCrudWithMongoDb.Context;
using DotNetCrudWithMongoDb.Models;
using MongoDB.Driver;

namespace DotNetCrudWithMongoDb.Services;

public class BooksService
{
    private readonly MongoDBContext _context;

    public BooksService(MongoDBContext mongoDBContext)
    {
        _context = mongoDBContext;
    }

    public async Task<List<Book>> GetAsync() =>
        await _context.Books.Find(_ => true).ToListAsync();

    public async Task<Book?> GetAsync(string id) =>
        await _context.Books.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Book newBook) =>
        await _context.Books.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Book updatedBook) =>
        await _context.Books.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _context.Books.DeleteOneAsync(x => x.Id == id);
}