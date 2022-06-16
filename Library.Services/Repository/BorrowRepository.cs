using Library.Data.Context;
using Library.DomainClasses.Classes;
using Library.Services.IRepository;

namespace Library.Services.Repository
{
    public class BorrowRepository : GenericRepository<Borrow>, IBorrowRepository
    {
        public BorrowRepository(LibraryContext context) : base(context) { }
    }
}
