using Library.DomainClasses.Auth;
using Library.DomainClasses.Classes;
using Library.Models.Classes;
using Library.UOW.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers.Admin
{
    [Authorize(Roles = UserRoles.Admin)]
    [Area("Admin")]
    [Route("[area]/api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public AuthorController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("[action]")]
        public IActionResult GetAuthors()
        {
            var list = _uow.Author.GetAll();
            if (list.Any())
                return Ok(list);

            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetById(int id)
        {
            var author = _uow.Author.GetById(id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost("[action]")]
        public IActionResult AddAuthor(AuthorModel authorModel)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var author = new Author()
            {
                Name = authorModel.Name,
                Family = authorModel.Family
            };

            _uow.Author.Add(author);
            _uow.Save();

            return Ok();
        }

        [HttpPut("[action]/{id}")]
        public IActionResult EditAuthor(int id, AuthorModel authorModel)
        {
            if(id != authorModel.Id)
                return BadRequest();

            var author = new Author()
            {
                Id = authorModel.Id,
                Name = authorModel.Name,
                Family = authorModel.Family
            };

            _uow.Author.Update(author);

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
        public IActionResult DeleteAuthor(int id)
        {
            var author = _uow.Author.GetById(id);
            if (author == null)
                return NotFound();

            _uow.Author.Remove(author);
            _uow.Save();

            return Ok();
        }
    }
}
