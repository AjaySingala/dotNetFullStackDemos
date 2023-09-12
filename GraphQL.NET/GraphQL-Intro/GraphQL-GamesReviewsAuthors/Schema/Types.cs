using GraphQL_GamesReviewsAuthors.Models;
using GraphQL_GamesReviewsAuthors.Repositories;

namespace GraphQL_GamesReviewsAuthors.Schema
{
    public class GameType : ObjectType<Game>
    {
        protected override void Configure(IObjectTypeDescriptor<Game> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Title).Type<StringType>();
            descriptor.Field(a => a.Platforms).Type<ListType<StringType>>();
            descriptor.Field(a => a.Reviews)
                .Type<ListType<ReviewType>>()
                .ResolveWith<Resolvers>(r => r.GetReviews(default!, default!));
            descriptor.Description("Games");
        }
    
        private class Resolvers
        {
            public List<Review> GetReviews([Parent] Game game, 
                [Service] IReviewRepository reviewRepository)
            {
                return reviewRepository.GetReviewsByGame(game.Id).Result;
            }
        }
    }

    public class ReviewType: ObjectType<Review>
    {
        protected override void Configure(IObjectTypeDescriptor<Review> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Rating).Type<IntType>();
            descriptor.Field(a => a.Content).Type<StringType>();
            descriptor.Field(a => a.GameId).Type<StringType>();
            descriptor.Field(a => a.AuthorId).Type<StringType>();
            descriptor.Field(a => a.Game).Type<GameType>();
            descriptor.Field(a => a.Game)
                .Type<GameType>()
                .ResolveWith<Resolvers>(r => r.GetGame(default!, default!)); 
            descriptor.Field(a => a.Author).Type<AuthorType>();
            descriptor.Description("Reviews");
        }

        private class Resolvers
        {
            public Game GetGame([Parent] Review review,
                [Service] IGameRepository gameRepository)
            {
                return gameRepository.GetGame(review.Game.Id).Result;
            }
        }
    }

    public class AuthorType : ObjectType<Author>
    {
          protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Name).Type<StringType>();
            descriptor.Field(a => a.Reviews).Type<ListType<ReviewType>>();
            descriptor.Description("Authors");
        }
    }
}
