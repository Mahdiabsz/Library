using Library.Controllers.Admin;
using Library.DomainClasses.Classes;
using Library.Models.Classes;
using Library.Tests.Data;
using Library.UOW.UOW;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Tests
{
    public class GenreControllerTest
    {
        [Fact]
        public void GetAll_ReturnOk()
        {
            /// Arrange
            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Genre.GetAll()).Returns(GenreMockData.GetGenres());
            var sut = new GenreController(_uow.Object);

            /// Act
            var result = sut.GetGenres();


            // /// Assert
            Assert.IsType<OkObjectResult>(result);

            var list = result as OkObjectResult;

            Assert.IsType<List<Genre>>(list.Value);



            var listGenres = list.Value as List<Genre>;

            Assert.Equal(3, listGenres.Count);
        }

        [Fact]
        public void GetAll_ReturnNoContent()
        {
            /// Arrange
            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Genre.GetAll()).Returns(GenreMockData.GetEmptyGenres());
            var sut = new GenreController(_uow.Object);

            /// Act
            var result = sut.GetGenres();


            /// Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetById_ReturnOk()
        {
            //Arrange
            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Genre.GetById(1)).Returns(GenreMockData.GetExistingGenre());
            var sut = new GenreController(_uow.Object);

            //Act
            var okResult = sut.GetById(1);

            //Assert
            Assert.IsType<OkObjectResult>(okResult);

            var item = okResult as OkObjectResult;
            Assert.IsType<Genre>(item.Value);

            var genre = item.Value as Genre;
            Assert.Equal(1, genre.Id);
            Assert.Equal("test1", genre.Name);
        }


        [Fact]
        public void GetById_ReturnNotFound()
        {
            //Arrange
            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Genre.GetById(4)).Returns((Genre)null);
            var sut = new GenreController(_uow.Object);

            //Act
            var notFoundResult = sut.GetById(4);

            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void AddGenre_ReturnOk()
        {
            //Arrange
            var genreModel = new GenreModel()
            {
                Name = "test"
            };

            var genre = new Genre()
            {
                Name = genreModel.Name
            };

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Genre.Add(genre));
            var sut = new GenreController(_uow.Object);

            //Act
            var result = sut.AddGenre(genreModel);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void AddGenre_ReturnBadRequest()
        {
            //Arrange
            var genreModel = new GenreModel();

            var genre = new Genre();

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Genre.Add(genre));
            var sut = new GenreController(_uow.Object);
            sut.ModelState.AddModelError("Name", "Required");

            //Act
            var result = sut.AddGenre(genreModel);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void EditGenre_ReturnOk()
        {
            //Arrange
            var genreModel = new GenreModel()
            {
                Id = 1,
                Name = "test"
            };

            var genre = new Genre()
            {
                Id = genreModel.Id,
                Name = genreModel.Name
            };

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Genre.Update(genre));
            var sut = new GenreController(_uow.Object);

            //Act
            var result = sut.EditGenre(1, genreModel);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void EditGenre_ReturnBadRequest()
        {
            //Arrange
            var genreModel = new GenreModel()
            {
                Id = 1,
                Name = "test"
            };

            var genre = new Genre()
            {
                Id = genreModel.Id,
                Name = genreModel.Name
            };

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Genre.Update(genre));
            var sut = new GenreController(_uow.Object);

            //Act
            var result = sut.EditGenre(2, genreModel);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Delete_OkResult()
        {
            var genre = new Genre()
            {
                Id = 1,
                Name = "test"
            };

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Genre.GetById(1)).Returns(GenreMockData.GetExistingGenre());
            _uow.Setup(x => x.Genre.Remove(genre));
            var sut = new GenreController(_uow.Object);


            //Act
            var result = sut.DeleteGenre(1);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Delete_NotFoundResult()
        {

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Genre.GetById(8)).Returns(GenreMockData.GetNotExistingGenre());
            var sut = new GenreController(_uow.Object);


            //Act
            var result = sut.DeleteGenre(8);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
