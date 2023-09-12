using GraphQL_GamesReviewsAuthors.Models;

namespace GraphQL_GamesReviewsAuthors.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> GetAuthor(string id);
        Task<List<Author>> GetAuthors();
    }
}
