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
        public async Task<Book> GetBook(int id)
        {
            var book = await _bookBusinessService.GetBook(id);
            if (book != null) { return book; }
            else throw new Exception("Wrong book returned!");
        }
        public async Task<Book> CreateBook(Book book)
        {
            var newbook = new Book();

                newbook.Name = book.Name;
                newbook.Authors = book.Authors;
 
            
            return await _bookBusinessService.CreateBook(newbook);
        }
        public async Task<Book> UpdateBook(int id, Book book)
        {
            var updatebook = await _bookBusinessService.GetBook(book.Id);
            if (updatebook.Id != null)
            {
                updatebook.Name = book.Name;
                //updatebook.Authors = book.Authors;
                await _bookBusinessService.UpdateBook(id,book);

                return updatebook;
            }
            else throw new Exception("Update error");
        }
        public Task<Book> DeleteBook(int id)
        {
 
            var deletebook = _bookBusinessService.GetBook(id);
    
            Console.WriteLine($"{deletebook.Id}");

            if (deletebook != null)
            {
                _bookBusinessService.DeleteBook(deletebook.Id);
                return deletebook;
            }
            else throw new Exception("Book remove failed.");
        }

    }
}
