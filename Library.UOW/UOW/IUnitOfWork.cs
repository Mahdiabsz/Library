using Library.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UOW.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Author { get; }
        IBookRepository Book { get; }
        IBorrowRepository Borrow { get; }
        IGenreRepository Genre { get; }
        int Save();
    }
}
