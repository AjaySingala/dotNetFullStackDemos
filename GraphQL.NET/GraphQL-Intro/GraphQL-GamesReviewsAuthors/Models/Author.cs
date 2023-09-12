namespace GraphQL_GamesReviewsAuthors.Models
{
    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
