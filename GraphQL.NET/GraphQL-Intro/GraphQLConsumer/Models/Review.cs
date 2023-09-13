namespace GraphQLConsumer.Models
{
    public class Review
    {
        public string Id { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
        public string GameId { get; set; }
        public string AuthorId { get; set; }
        public Game Game { get; set; }
        public Author Author { get; set; }
    }
}
