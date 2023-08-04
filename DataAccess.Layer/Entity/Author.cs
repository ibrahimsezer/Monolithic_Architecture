using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Entity
{
    public class Author
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<Book> Books { get; set; }
        
    }
}
