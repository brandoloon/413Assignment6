using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment6.Models
{
    public interface IBookStoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
