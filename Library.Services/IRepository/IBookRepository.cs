using Library.DomainClasses.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.IRepository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> GetAllInclude(int pageSize, int pageNumber);
        IEnumerable<Book> GetAuthorBooks(int authorId, int pageSize, int pageNumber);
        IEnumerable<Book> GetGenreBooks(int genreId, int pageSize, int pageNumber);
    }
}
