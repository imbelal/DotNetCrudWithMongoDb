using DotNetCrudWithMongoDb.Models;
using DotNetCrudWithMongoDb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCrudWithMongoDb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMongoRepository<Book> _bookRepository;

    public BooksController(IMongoRepositoryFactory repositoryFactory)
    {
        _bookRepository = repositoryFactory.CreateRepository<Book>("Books");
    }

    [HttpGet]
    public async Task<List<Book>> GetAllAsync()
    {
        return await _bookRepository.GetAllAsync();
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Book>> GetByIdAsync(string id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(Book newBook)
    {
        await _bookRepository.AddAsync(newBook);

        return CreatedAtAction(nameof(GetByIdAsync), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> UpdateAsync(string id, Book updatedBook)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _bookRepository.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _bookRepository.DeleteAsync(id);

        return NoContent();
    }
}