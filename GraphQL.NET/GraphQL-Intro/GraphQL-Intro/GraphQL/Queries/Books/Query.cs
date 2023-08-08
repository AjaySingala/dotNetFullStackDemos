using GraphQL_Intro.Models;
using GraphQL_Intro.Repositories.Interfaces;
using HotChocolate.Subscriptions;

#region Sample GraphQL Query

/* Write your query or mutation here
Books:
query {
  allBooks {
    id
    title
    author {
      id
      name
    }
  }
  book(id: 101) {
    id
    title
    author {
      id
      name
    }
  }
}

Multiple queries:
query GetAllBooks {
  allBooks {
    id
    title
    author {
      id
      name
    }
  }
}
query GetBook {
  book(id: 101) {
    id
    title
    author {
      id
      name
    }
  }
}
*/

#endregion

namespace GraphQL_Intro.GraphQL.Queries
{
    public partial class Query
    {
        #region Books.

        public async Task<List<Book>> GetAllBooksAsync(
            [Service] IBookRepository repository,
            [Service] ITopicEventSender eventSender)
        {
            var books = await repository.GetBooksAsync();
            await eventSender.SendAsync("Returned a list of Books", books);

            return books;
        }

        public async Task<Book> GetBookAsync(
            [Service] IBookRepository repository,
            [Service] ITopicEventSender eventSender,
            int id)
        {
            var Book = await repository.GetBookAsync(id);
            await eventSender.SendAsync("Returned an Book", Book);

            return Book;
        }

        #endregion
    }
}
