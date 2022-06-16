using Library.Data.Context;
using Library.DomainClasses.Classes;
using Library.Services.IRepository;

namespace Library.Services.Repository
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(LibraryContext context) : base(context) { }
    }
}
