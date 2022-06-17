using Library.DomainClasses.Auth;
using Library.DomainClasses.Classes;
using Library.Models.Classes;
using Library.UOW.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.User
{
    [Authorize(Roles = UserRoles.User)]
    [Area("User")]
    [Route("[area]/api/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public BookController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost("[action]")]
        public ActionResult<IEnumerable<BookGetAllModel>> GetBooks(Pager pager)
        {
            var books = _uow.Book.GetAllInclude(pager.PageSize, pager.PageNumber);
            if (books.Any())
            {
                var list = new List<BookGetAllModel>();
                foreach (var book in books)
                {
                    list.Add(new BookGetAllModel()
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Description = book.Description,
                        Stock = book.Stock,
                        Author = book.Author.Name + " " + book.Author.Family,
                        Genre = book.Genre.Name
                    });
                }

                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("[action]")]
        public ActionResult<IEnumerable<BookGetAllModel>> GetAuthorBooks(PagerWithAuthor pager)
        {
            var books = _uow.Book.GetAuthorBooks(pager.AuthorId, pager.PageSize, pager.PageNumber);
            if (books.Any())
            {
                var list = new List<BookGetAllModel>();
                foreach (var book in books)
                {
                    list.Add(new BookGetAllModel()
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Description = book.Description,
                        Stock = book.Stock,
                        Author = book.Author.Name + " " + book.Author.Family,
                        Genre = book.Genre.Name
                    });
                }

                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("[action]")]
        public ActionResult<IEnumerable<BookGetAllModel>> GetGenreBooks(PagerWithGenre pager)
        {
            var books = _uow.Book.GetGenreBooks(pager.GenreId, pager.PageSize, pager.PageNumber);
            if (books.Any())
            {
                var list = new List<BookGetAllModel>();
                foreach (var book in books)
                {
                    list.Add(new BookGetAllModel()
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Description = book.Description,
                        Stock = book.Stock,
                        Author = book.Author.Name + " " + book.Author.Family,
                        Genre = book.Genre.Name
                    });
                }

                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<BookGetModel> GetById(int id)
        {
            var book = _uow.Book.GetById(id);
            if (book == null)
                return NotFound();

            book.Author = _uow.Author.GetById(book.AuthorId);
            book.Genre = _uow.Genre.GetById(book.GenreId);

            var obj = new BookGetModel()
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                Stock = book.Stock,
                AuthorId = book.AuthorId,
                Author = book.Author.Name + " " + book.Author.Family,
                GenreId = book.GenreId,
                Genre = book.Genre.Name
            };

            return Ok(obj);
        }
    }
}
