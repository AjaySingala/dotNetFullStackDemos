using GraphQL_GamesReviewsAuthors.Models;
using GraphQL_GamesReviewsAuthors.Repositories;
using HotChocolate.Subscriptions;

namespace GraphQL_GamesReviewsAuthors.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class AuthorGraphQLQueries
    {
        public async Task<List<Author>> GetAllAuthors(
            [Service] IAuthorRepository authorRepository
        )
        {
            List<Author> Authors = await authorRepository.GetAuthors();
            return Authors;
        }

        public async Task<Author> GetAuthor(
            [Service] IAuthorRepository authorRepository,
            string id)
        {
            var Author = await authorRepository.GetAuthor(id);
            return Author;
        }
    }
}
