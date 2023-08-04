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
    public  class AuthorRepo : IAuthorRepo
    {
        private readonly DataAccess _context;

        public AuthorRepo(DataAccess context)
        {
            _context = context;
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> DeleteAuthor(int Id)
        {
            _context.Authors.ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Author> GetAuthor(int Id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == Id);
            return author;
        }
    }
}
