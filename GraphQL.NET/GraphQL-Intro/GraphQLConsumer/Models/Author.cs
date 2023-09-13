namespace GraphQLConsumer.Models
{
    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
