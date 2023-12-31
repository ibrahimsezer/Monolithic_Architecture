﻿using DataAccess.Layer.Entity;
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
        public async Task<Book> GetBook(int Id)
        {
            var book = await _context.Books.SingleAsync(x => x.Id == Id);
            Console.WriteLine($"{book.Id} : {book.Name} ");
            return book;
        }
        public async Task<Book> CreateBook(Book book)
        {   Book book1 = new Book();
            book1.Name = book.Name;
            book1.Authors = book.Authors;

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book1;
        }
        public async Task<Book> UpdateBook(int id, Book book)
        {
            var newbook = await _context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
            if (newbook.Id == book.Id)
            {

                //newbook.Authors = book.Authors;
                newbook.Name = book.Name;
                await _context.SaveChangesAsync();
                return newbook;
            }
            else throw new Exception("Error ID is null here.");

        }
        public async Task<Book> DeleteBook(int Id)
        {
            var deletebook = await _context.Books.FindAsync(Id);
            Console.WriteLine($"{deletebook.Id}");

            if (deletebook != null)
            {
                _context.Books.Remove(deletebook);
                await _context.SaveChangesAsync();
                return deletebook;
            }
            else throw new Exception("Book not found.");
          
        }
    }
}
