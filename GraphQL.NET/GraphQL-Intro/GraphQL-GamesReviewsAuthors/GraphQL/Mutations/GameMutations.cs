using GraphQL_GamesReviewsAuthors.GraphQL.Inputs;
using GraphQL_GamesReviewsAuthors.Models;
using GraphQL_GamesReviewsAuthors.Repositories;
using HotChocolate.Language;

namespace GraphQL_GamesReviewsAuthors.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class GameMutations
    {
        public async Task<Game> AddGame(
            [Service] IGameRepository gameRepository,
            AddGameInput input)
        {
            Game game = await gameRepository.AddGame(input);
            return game;
        }

        public async Task<Game> UpdateGame(
            [Service] IGameRepository gameRepository,
            string id,
            EditGameInput input)
        {
            Game game = await gameRepository.UpdateGame(id, input);
            return game;
        }

        public async Task<List<Game>> DeleteGame(
            [Service] IGameRepository gameRepository,
            string id)
        {
            var games = await gameRepository.DeleteGame(id);
            return games;
        }
    }
}
