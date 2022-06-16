using Library.Data.Context;
using Library.DomainClasses.Classes;
using Library.Services.IRepository;

namespace Library.Services.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(LibraryContext context) : base(context) { }
    }
}
