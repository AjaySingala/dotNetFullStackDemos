using GraphQL_Intro.Models;

namespace GraphQL_Intro.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
        Task<Book> UpdateBookAsync(int id, Book book);
    }
}
