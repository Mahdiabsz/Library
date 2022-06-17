using Library.Data.Context;
using Library.Services.IRepository;
using Library.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UOW.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryContext _context;
        public UnitOfWork(LibraryContext context)
        {
            _context = context;
            Author = new AuthorRepository(_context);
            Book = new BookRepository(_context);
            Borrow = new BorrowRepository(_context);
            Genre = new GenreRepository(_context);
        }
        public IAuthorRepository Author { get; private set; }
        public IBookRepository Book { get; private set; }
        public IBorrowRepository Borrow { get; private set; }
        public IGenreRepository Genre { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
