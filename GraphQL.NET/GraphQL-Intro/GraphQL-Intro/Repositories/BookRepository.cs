using GraphQL_Intro.GraphQL.Books;
using GraphQL_Intro.Models;
using GraphQL_Intro.Repositories.Interfaces;

namespace GraphQL_Intro.Repositories
{
    public class BookRepository : IBookRepository
    {
        static private readonly List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 101,
                Title = "Graffiti - Part 1",
                Author = (new AuthorRepository()).GetAuthorAsync(1).Result
            },
            new Book
            {
                Id = 102,
                Title = "Graffiti - Part 2",
                Author = (new AuthorRepository()).GetAuthorAsync(2).Result
            },
            new Book
            {
                Id = 103,
                Title = "Graffiti - Part 3",
                Author = (new AuthorRepository()).GetAuthorAsync(3).Result
            }
        };

        public async Task<List<Book>> GetBooksAsync()
        {
            return await Task.FromResult(books);
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await Task.FromResult(books.FirstOrDefault(x => x.Id == id));
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            book.Id = books.Max(x => x.Id) + 1;
            books.Add(book);
            return await Task.FromResult(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            books.Remove(book);
            return await Task.FromResult(true);
        }

        public async Task<Book> UpdateBookAsync(int id, Book book)
        { 
            var bookToUpdate = books.FirstOrDefault(x => x.Id == id);
            if(bookToUpdate != null)
                bookToUpdate.Title = book.Title; 
            return await Task.FromResult(book);
        }
    }
}
