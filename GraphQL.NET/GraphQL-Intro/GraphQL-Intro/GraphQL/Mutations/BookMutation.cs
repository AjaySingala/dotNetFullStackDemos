using GraphQL_Intro.GraphQL.Inputs;
using GraphQL_Intro.GraphQL.Payloads;
using GraphQL_Intro.Models;
using GraphQL_Intro.Repositories.Interfaces;
using HotChocolate.Language;
using System.Net;

#region Sample GraphQL Query

/*
mutation AddBook {
  addBook(input: {
    title: "Bitcoin for Dummies"
    authorId: 2
  })
  {
    book {
      id
    }
  }
}

mutation DeleteBook {
  deleteBook(bookId: 104) {
    id
  }
}

mutation UpdateBook {
  updateBook(input: {
    id: 104
    title: "Bitcoin for Dummies"
  }) 
  {
    id
    title
  }
}
*/

#endregion

namespace GraphQL_Intro.GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<AddBookPayload> AddBookAsync(
            AddBookInput input,
            [Service] IBookRepository repository,
            [Service] IAuthorRepository authorRepository,
            CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = input.Title,
                Author = authorRepository.GetAuthorAsync(input.AuthorId).Result
            };

            //await repository.AddAuthorAsync(author, cancellationToken);
            await repository.AddBookAsync(book);

            return new AddBookPayload(book);
        }

        public async Task<Book> DeleteBookAsync(
            int bookId,
            [Service] IBookRepository repository,
            CancellationToken cancellationToken)
        {
            var book = repository.GetBookAsync(bookId).Result;

            //await repository.AddAuthorAsync(author, cancellationToken);
            await repository.DeleteBookAsync(bookId);

            return book;
        }

        public async Task<Book> UpdateBookAsync(
            DeleteBookInput input,
            [Service] IBookRepository repository,
            CancellationToken cancellationToken)
        {

            var book = new Book
            {
                Id = input.Id,
                Title = input.Title
            };
            await repository.UpdateBookAsync(input.Id, book);

            return book;
        }
    }
}
