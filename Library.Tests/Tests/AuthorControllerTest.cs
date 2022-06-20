using Library.Controllers.Admin;
using Library.Data.Context;
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
    public class AuthorControllerTest
    {
        [Fact]
        public void GetAll_ReturnOk()
        {
            /// Arrange
            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Author.GetAll()).Returns(AuthorMockData.GetAuthors());
            var sut = new AuthorController(_uow.Object);

            /// Act
            var result = sut.GetAuthors();


            // /// Assert
            Assert.IsType<OkObjectResult>(result);

            var list = result as OkObjectResult;

            Assert.IsType<List<Author>>(list.Value);



            var listAuthors = list.Value as List<Author>;

            Assert.Equal(3, listAuthors.Count);
        }

        [Fact]
        public void GetAll_ReturnNoContent()
        {
            /// Arrange
            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Author.GetAll()).Returns(AuthorMockData.GetEmptyAuthor());
            var sut = new AuthorController(_uow.Object);

            /// Act
            var result = sut.GetAuthors();


            /// Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetById_ReturnOk()
        {
            //Arrange
            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Author.GetById(1)).Returns(AuthorMockData.GetExistingAuthor());
            var sut = new AuthorController(_uow.Object);

            //Act
            var okResult = sut.GetById(1);

            //Assert
            Assert.IsType<OkObjectResult>(okResult);

            var item = okResult as OkObjectResult;
            Assert.IsType<Author>(item.Value);

            var author = item.Value as Author;
            Assert.Equal(1, author.Id);
            Assert.Equal("mahdi", author.Name);
            Assert.Equal("abbaszadeh", author.Family);
        }


        [Fact]
        public void GetById_ReturnNotFound()
        {
            //Arrange
            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Author.GetById(4)).Returns((Author)null);
            var sut = new AuthorController(_uow.Object);

            //Act
            var notFoundResult = sut.GetById(4);

            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void AddAuthor_ReturnOk()
        {
            //Arrange
            var authorModel = new AuthorModel()
            {
                Name = "mahdi",
                Family = "abbaszadeh"
            };

            var author = new Author()
            {
                Name = authorModel.Name,
                Family = authorModel.Family
            };

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Author.Add(author));
            var sut = new AuthorController(_uow.Object);

            //Act
            var result = sut.AddAuthor(authorModel);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void AddAuthor_ReturnBadRequest()
        {
            //Arrange
            var authorModel = new AuthorModel()
            {
                Name = "ali"
            };

            var author = new Author()
            {
                Name = authorModel.Name
            };

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Author.Add(author));
            var sut = new AuthorController(_uow.Object);
            sut.ModelState.AddModelError("Family", "Required");

            //Act
            var result = sut.AddAuthor(authorModel);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void EditAuthor_ReturnOk()
        {
            //Arrange
            var authorModel = new AuthorModel()
            {
                Id = 1,
                Name = "mahdi",
                Family = "abbaszadeh"
            };

            var author = new Author()
            {
                Id = authorModel.Id,
                Name = authorModel.Name,
                Family = authorModel.Family
            };

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Author.Update(author));
            var sut = new AuthorController(_uow.Object);

            //Act
            var result = sut.EditAuthor(1, authorModel);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void EditAuthor_ReturnBadRequest()
        {
            //Arrange
            var authorModel = new AuthorModel()
            {
                Id = 1,
                Name = "mahdi",
                Family = "abbaszadeh"
            };

            var author = new Author()
            {
                Id = authorModel.Id,
                Name = authorModel.Name,
                Family = authorModel.Family
            };

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Author.Update(author));
            var sut = new AuthorController(_uow.Object);

            //Act
            var result = sut.EditAuthor(2, authorModel);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Delete_OkResult()
        {
            var author = new Author()
            {
                Id = 1,
                Name = "mahdi",
                Family = "abbaszadeh",
            };

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Author.GetById(1)).Returns(AuthorMockData.GetExistingAuthor());
            _uow.Setup(x => x.Author.Remove(author));
            var sut = new AuthorController(_uow.Object);


            //Act
            var result = sut.DeleteAuthor(1);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Delete_NotFoundResult()
        {

            var _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.Author.GetById(8)).Returns(AuthorMockData.GetNotExistingAuthor());
            var sut = new AuthorController(_uow.Object);


            //Act
            var result = sut.DeleteAuthor(8);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
