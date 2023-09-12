using GraphQL_GamesReviewsAuthors.Models;

namespace GraphQL_GamesReviewsAuthors.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private static List<Review> _reviews = new List<Review>()
        {
            new Review { Id = "1", GameId = "1", AuthorId = "3", Rating = 3, Content = "This game is average!" },
            new Review { Id = "2", GameId = "2", AuthorId = "2", Rating = 4, Content = "This game is awesome!" },
            new Review { Id = "3", GameId = "3", AuthorId = "1", Rating = 5, Content = "This game is brilliant!" },
            new Review { Id = "4", GameId = "4", AuthorId = "1", Rating = 2, Content = "This game is lousy!" },
            new Review { Id = "5", GameId = "5", AuthorId = "3", Rating = 5, Content = "This game is excellent!" },
            new Review { Id = "6", GameId = "1", AuthorId = "1", Rating = 2, Content = "This game is lousy!" },
            new Review { Id = "7", GameId = "2", AuthorId = "3", Rating = 4, Content = "This game is amazing!" },
        };

        public ReviewRepository(IGameRepository gamesRepo, IAuthorRepository authorRepo)
        {
            foreach(var review in _reviews)
            {
                review.Game = gamesRepo.GetGame(review.GameId).Result;
                review.Author = authorRepo.GetAuthor(review.AuthorId).Result;

                review.Game.Reviews = this.GetReviewsByGame(review.GameId).Result;
            }
        }

        public async Task<Review> GetReview(string id)
        {
            return await Task.FromResult(_reviews.FirstOrDefault(r => r.Id == id));            
        }

        public async Task<List<Review>> GetReviews()
        {
            return await Task.FromResult(_reviews);
        }

        public async Task<List<Review>> GetReviewsByGame(string gameId)
        {
            return await Task.FromResult(_reviews.Where(r => r.GameId == gameId).ToList());
        }
    }
}
