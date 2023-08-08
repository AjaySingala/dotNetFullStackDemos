using GraphQL_Intro.Models;

namespace GraphQL_Intro.GraphQL.Payloads
{
    public class AddAuthorPayload
    {
        public Author Author { get; }

        public AddAuthorPayload(Author author)
        {
            Author = author;
        }
    }
}
