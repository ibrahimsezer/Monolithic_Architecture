using DataAccess.Layer.Entity;

namespace BusinessService.Layer.Interface
{
    public interface IBookBusinessService
    {
        Task<Book> GetBook(int id);
        Task<Book> CreateBook(Book book);
        Task<Book> DeleteBook(Book book);


    }
}