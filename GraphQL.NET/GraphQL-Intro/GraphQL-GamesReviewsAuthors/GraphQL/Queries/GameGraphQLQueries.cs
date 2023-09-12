using GraphQL_GamesReviewsAuthors.Models;
using GraphQL_GamesReviewsAuthors.Repositories;
using HotChocolate.Subscriptions;

namespace GraphQL_GamesReviewsAuthors.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class GameGraphQLQueries
    {
        IReviewRepository _reviewRepository;

        public GameGraphQLQueries(IReviewRepository reviewRepo)
        {
            _reviewRepository = reviewRepo;
        }

        public async Task<List<Game>> GetAllGames(
            [Service] IGameRepository gameRepository
        //,
        //[Service] ITopicEventSender eventSender
        )
        {
            List<Game> games = await gameRepository.GetGames();
            foreach( Game game in games )
            {
                  game.Reviews = await _reviewRepository.GetReviewsByGame(game.Id);
            }
            //await eventSender.SendAsync("Returned a list of Games",
            //  games);
            return games;
        }

        public async Task<Game> GetGame(
            [Service] IGameRepository gameRepository,
            [Service] ITopicEventSender eventSender,
            string id)
        {
            Game game = await gameRepository.GetGame(id);
            await eventSender.SendAsync("Returned a Game",
              game);
            return game;
        }
    }
}
