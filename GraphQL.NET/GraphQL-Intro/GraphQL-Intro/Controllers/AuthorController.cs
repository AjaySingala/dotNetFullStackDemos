using GraphQL_Intro.Models;
using GraphQL_Intro.Repositories;
using GraphQL_Intro.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository repository)
        {
            _authorRepository = repository;
        }

        [HttpGet("{id}")]
        public async Task<Author> GetAuthor(int id)
        {
            return await _authorRepository.GetAuthorAsync(id);
        }

        //[HttpGet("GetAuthors")]
        public async Task<List<Author>> GetAuthors()
        {
            return await _authorRepository.GetAuthorsAsync();
        }

        [HttpPost]

        public async Task<Author> AddAuthor(Author author)
        {
            return await _authorRepository.AddAuthorAsync(author);
        }
    }
}
