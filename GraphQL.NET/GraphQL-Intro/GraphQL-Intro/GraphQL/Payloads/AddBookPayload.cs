using GraphQL_Intro.Models;

namespace GraphQL_Intro.GraphQL.Payloads
{
    public class AddBookPayload
    {
        public Book Book{ get; }

        public AddBookPayload(Book book)
        {
            Book = book;
        }
    }
}
