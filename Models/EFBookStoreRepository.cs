using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class EFBookStoreRepository : IBookStoreRepository
    {
        private BookStoreDbContext context;

        public EFBookStoreRepository(BookStoreDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Book> Books => context.Books;

    }
}
