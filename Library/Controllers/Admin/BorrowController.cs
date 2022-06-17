using Library.DomainClasses.Auth;
using Library.UOW.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Admin
{
    [Authorize(Roles = UserRoles.Admin)]
    [Area("Admin")]
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

        [HttpPut("[action]/{id}")]
        public IActionResult SetDelivered(int id)
        {
            var borrow = _uow.Borrow.GetById(id);
            if(borrow == null)
                return NotFound();

            borrow.IsDeivered = true;
            borrow.DateOfDeliver = DateTime.Now;
            _uow.Borrow.Update(borrow);

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
    }
}
