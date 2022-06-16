using Library.Data.Context;
using Library.DomainClasses.Classes;
using Library.Services.IRepository;

namespace Library.Services.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext context) : base(context) { }
    }
}
