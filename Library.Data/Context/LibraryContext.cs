using Library.DomainClasses.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options) { }

        #region DomainClasses
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        #endregion
    }
}
