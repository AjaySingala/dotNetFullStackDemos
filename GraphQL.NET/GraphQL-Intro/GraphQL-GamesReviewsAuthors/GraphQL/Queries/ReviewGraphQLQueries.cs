using GraphQL_GamesReviewsAuthors.Models;
using GraphQL_GamesReviewsAuthors.Repositories;
using HotChocolate.Subscriptions;

namespace GraphQL_GamesReviewsAuthors.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class ReviewGraphQLQueries
    {
        public async Task<List<Review>> GetAllReviews(
            [Service] IReviewRepository reviewRepository
        )
        {
            List<Review> reviews = await reviewRepository.GetReviews();
            return reviews;
        }

        public async Task<Review> GetReview(
            [Service] IReviewRepository reviewRepository,
            string id)
        {
            var review = await reviewRepository.GetReview(id);
            return review;
        }
    }
}
