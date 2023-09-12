using GraphQL_GamesReviewsAuthors.Models;

namespace GraphQL_GamesReviewsAuthors.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private static List<Author> _authors = new List<Author>
        {
            new Author{Id = "1", Name = "John Smith"},
            new Author{Id = "2", Name = "Mary Jane"},
            new Author{Id = "3", Name = "Neo Trinity"},
        };

        public async Task<Author> GetAuthor(string id)
        {
            return await Task.FromResult(_authors.FirstOrDefault(a => a.Id == id));
        }

        public async Task<List<Author>> GetAuthors()
        {
            return await Task.FromResult(_authors);
        }
    }
}
