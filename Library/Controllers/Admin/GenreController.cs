using Library.DomainClasses.Auth;
using Library.DomainClasses.Classes;
using Library.Models.Classes;
using Library.UOW.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Admin
{
    [Authorize(Roles = UserRoles.Admin)]
    [Area("Admin")]
    [Route("[area]/api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public GenreController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Genre>> GetGenres()
        {
            var list = _uow.Author.GetAll();
            return Ok(list);
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<Genre> GetById(int id)
        {
            var genre = _uow.Genre.GetById(id);

            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        [HttpPost("[action]")]
        public IActionResult AddGenre(GenreModel genreModel)
        {
            try
            {
                var genre = new Genre()
                {
                    Name = genreModel.Name,
                };

                _uow.Genre.Add(genre);
                _uow.Save();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("[action]/{id}")]
        public IActionResult EditGenre(int id, GenreModel genreModel)
        {
            if (id != genreModel.Id)
                return BadRequest();

            var genre = new Genre()
            {
                Id = genreModel.Id,
                Name = genreModel.Name
            };

            _uow.Genre.Update(genre);

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
        public IActionResult DeleteGenre(int id)
        {
            var genre = _uow.Genre.GetById(id);
            if (genre == null)
                return NotFound();

            _uow.Genre.Remove(genre);
            _uow.Save();

            return Ok();
        }
    }
}
