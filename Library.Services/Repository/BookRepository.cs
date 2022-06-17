using Library.Data.Context;
using Library.DomainClasses.Classes;
using Library.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context) { }

        public IEnumerable<Book> GetAllInclude(int pageSize, int pageNumber)
        {
            return context.Books.Skip(pageSize * pageNumber).Take(pageSize).Include(x => x.Author).Include(x => x.Genre);
        }

        public IEnumerable<Book> GetAuthorBooks(int authorId, int pageSize, int pageNumber)
        {
            return context.Books.Where(x => x.AuthorId == authorId).Skip(pageSize * pageNumber).Take(pageSize).Include(x => x.Author).Include(x => x.Genre);
        }

        public IEnumerable<Book> GetGenreBooks(int genreId, int pageSize, int pageNumber)
        {
            return context.Books.Where(x => x.GenreId == genreId).Skip(pageSize * pageNumber).Take(pageSize).Include(x => x.Author).Include(x => x.Genre);
        }
    }
}
