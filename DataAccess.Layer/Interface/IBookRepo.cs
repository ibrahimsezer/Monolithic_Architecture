using DataAccess.Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Interface
{
    public interface IBookRepo
    {
        Task<Book> GetBook(int Id);
        Task<Book> CreateBook(Book book);
        Task<Book> DeleteBook(int Id);
        Task<Book> UpdateBook (Book book);
    }
}
