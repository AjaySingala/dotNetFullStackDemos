namespace GraphQL_GamesReviewsAuthors.Models
{
    public class Game
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<string> Platforms { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
