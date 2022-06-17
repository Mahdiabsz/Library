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
    public class BorrowController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public BorrowController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost("[action]")]
        public IActionResult BorrowBook(UserBorrowModel model)
        {
            try
            {
                var book = _uow.Book.GetById(model.BookId);
                if (book == null)
                    return NotFound();
                else
                {
                    if (book.Stock > 0)
                    {
                        var userId = User.FindFirst("Id")?.Value;
                        var borrow = new Borrow()
                        {
                            BookId = model.BookId,
                            UserId = userId,
                            DateOfBorrow = DateTime.Now
                        };

                        book.Stock -= 1;
                        _uow.Borrow.Add(borrow);
                        _uow.Book.Update(book);
                        _uow.Save();

                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
