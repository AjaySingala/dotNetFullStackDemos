using GraphQL_Intro.Models;
using GraphQL_Intro.Repositories;
using GraphQL_Intro.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository repository)
        {
            _bookRepository = repository;
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBook(int id)
        {
            return await _bookRepository.GetBookAsync(id);
        }

        //[HttpGet("GetBooks")]
        public async Task<List<Book>> GetBooks()
        {
            return await _bookRepository.GetBooksAsync();
        }

        [HttpPost]

        public async Task<Book> AddBook(Book book)
        {
            return await _bookRepository.AddBookAsync(book);
        }
    }
}
