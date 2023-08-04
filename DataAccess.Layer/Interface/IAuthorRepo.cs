using DataAccess.Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Interface
{
    public interface IAuthorRepo
    {
        Task<Author> GetAuthor(int Id);
        Task<Author> CreateAuthor(Author author);
        Task<Author> DeleteAuthor(int Id);

    }
}
