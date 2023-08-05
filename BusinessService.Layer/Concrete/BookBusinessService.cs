using BusinessService.Layer.Interface;
using DataAccess.Layer.Concrete;
using DataAccess.Layer.Entity;
using DataAccess.Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Layer.Concrete
{
public class BookBusinessService : IBookBusinessService
    {
        private readonly IBookRepo _bookBusinessService;

        public BookBusinessService(IBookRepo bookBusinessService)
        {
            _bookBusinessService = bookBusinessService;
        }

        public async Task<Book> CreateBook(Book book)
        {
            var newbook = new Book()
            {
                Name = book.Name
            };
            return await _bookBusinessService.CreateBook(newbook);
        }

        public Task<Book> DeleteBook(Book book)
        {
            var deletebook = _bookBusinessService.GetBook(book.Id);
            if (deletebook != null)
            {
                _bookBusinessService.DeleteBook(book.Id);
                return null;
            }
            else throw new Exception("Book remove failed.");
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await _bookBusinessService.GetBook(id);
            if (book.Id == id) { return book; }
            else throw new Exception("Wrong book returned!");
        }
    }
}
