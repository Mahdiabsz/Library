using Library.Data.Context;
using Library.DomainClasses.Classes;
using Library.Services.IRepository;

namespace Library.Services.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context) { }
    }
}
