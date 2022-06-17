using Library.DomainClasses.Auth;
using Library.DomainClasses.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Library.Data.Configs;

namespace Library.Data.Context
{
    public class LibraryContext : IdentityDbContext<MyUser>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }

        #region DomainClasses
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Genre> Genres { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BookConfig());
            builder.ApplyConfiguration(new GenreConfig());
            builder.ApplyConfiguration(new BorrowConfig());
            builder.ApplyConfiguration(new AuthorConfig());

        }
    }
}
