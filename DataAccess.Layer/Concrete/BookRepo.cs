using DataAccess.Layer.Entity;
using DataAccess.Layer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Concrete
{
    public class BookRepo:IBookRepo
    {
        private readonly DataAccess _context;

        public BookRepo(DataAccess context)
        {
            _context = context;
        }

        public async Task<Book> CreateBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBook(int Id)
        {
            _context.Books.ExecuteDeleteAsync();
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Book> GetBook(int Id)
        {
            var book =await _context.Books.FirstOrDefaultAsync(x => x.Id == Id);

            return book;
        }
    }
}
