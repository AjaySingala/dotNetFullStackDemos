using GraphQL_GamesReviewsAuthors.GraphQL.Inputs;
using GraphQL_GamesReviewsAuthors.Models;

namespace GraphQL_GamesReviewsAuthors.Repositories
{
    public interface IGameRepository
    {
        Task<List<Game>> GetGames();
        Task<Game> GetGame(string id);
        Task<Game> AddGame(AddGameInput input);
        Task<Game> UpdateGame(string id, EditGameInput input);
        Task<List<Game>> DeleteGame(string id);
    }
}
