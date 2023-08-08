using GraphQL_Intro.Models;

namespace GraphQL_Intro.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
    }
}
