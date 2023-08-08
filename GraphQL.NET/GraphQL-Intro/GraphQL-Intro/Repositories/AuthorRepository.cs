using GraphQL_Intro.GraphQL.Books;
using GraphQL_Intro.Models;
using GraphQL_Intro.Repositories.Interfaces;

namespace GraphQL_Intro.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        static private readonly List<Author> authors = new List<Author>
        {
            new Author
            {
                Id = 1,
                Name = "Aaron"
            },
            new Author
            {
                Id = 2,
                Name = "Gilly"
            },
            new Author
            {
                Id = 3,
                Name = "Phantom"
            }
        };

        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await Task.FromResult(authors);
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            return await Task.FromResult(authors.FirstOrDefault(x => x.Id == id));
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            author.Id = authors.Max(x => x.Id) + 1;
            authors.Add(author);
            return await Task.FromResult(author);
        }

    }
}
