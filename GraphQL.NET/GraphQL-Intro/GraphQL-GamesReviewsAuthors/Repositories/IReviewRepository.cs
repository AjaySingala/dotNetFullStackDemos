using GraphQL_GamesReviewsAuthors.Models;

namespace GraphQL_GamesReviewsAuthors.Repositories
{
    public interface IReviewRepository
    {
        Task<Review> GetReview(string id);
        Task<List<Review>> GetReviews();
        Task<List<Review>> GetReviewsByGame(string gameId);
        //Task<List<Review>> GetReviewsByGameIdAsync(int gameId);
        //Task<List<Review>> GetReviewsByAuthorIdAsync(int authorId);
        //Task<Review> AddReviewAsync(Review review);
        //Task<Review> UpdateReviewAsync(Review review);
        //Task<Review> DeleteReviewAsync(int id);
    }
}
