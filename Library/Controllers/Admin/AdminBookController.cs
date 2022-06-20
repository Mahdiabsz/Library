using Library.DomainClasses.Auth;
using Library.DomainClasses.Classes;
using Library.Models.Classes;
using Library.UOW.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Admin
{
    [Authorize(Roles = UserRoles.Admin)]
    [Area("Admin")]
    [Route("[area]/api/[controller]")]
    [ApiController]
    public class AdminBookController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public AdminBookController(IUnitOfWork uow)
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
                return NoContent();
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

        [HttpPost("[action]")]
        public IActionResult AddBook(BookModel bookModel)
        {
            try
            {
                var book = new Book()
                {
                    Name = bookModel.Name,
                    Description = bookModel.Description,
                    Stock = bookModel.Stock,
                    AuthorId = bookModel.AuthorId,
                    GenreId = bookModel.GenreId
                };

                _uow.Book.Add(book);
                _uow.Save();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("[action]/{id}")]
        public IActionResult EditBook(int id, BookModel bookModel)
        {
            if (id != bookModel.Id)
                return BadRequest();

            var book = new Book()
            {
                Id = bookModel.Id,
                Name = bookModel.Name,
                Description = bookModel.Description,
                Stock = bookModel.Stock,
                AuthorId = bookModel.AuthorId,
                GenreId = bookModel.GenreId
            };

            _uow.Book.Update(book);

            try
            {
                _uow.Save();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("[action]/{id}")]
        public IActionResult EditBookStock(int id, BookStockModel model)
        {
            if (id != model.Id)
                return BadRequest();


            var book = _uow.Book.GetById(id);
            book.Stock = model.Stock;

            _uow.Book.Update(book);

            try
            {
                _uow.Save();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _uow.Book.GetById(id);
            if (book == null)
                return NotFound();

            _uow.Book.Remove(book);
            _uow.Save();

            return Ok();
        }
    }
}
