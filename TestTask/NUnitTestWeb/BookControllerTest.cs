using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Application;
using TestTask.Application.Models;
using TestTask.Web.Controllers;

namespace NUnitTestWeb
{
    public class BookControllerTest
    {
        private BookController _bookController;
        private Mock<IBookService> _bookService;
        private BookModelDTO _bookModelDTO;
        private List<BookModelDTO> _bookModelDTOs;
        private int BookId;

        [SetUp]
        public void Setup()
        {
            _bookService = new Mock<IBookService>();
            _bookController = new BookController(_bookService.Object);
            _bookModelDTO = new BookModelDTO
            {
                Id = 2,
                NameOfAuthor = "Volodya",
                SureNameOfAuthor = "Khydzik",
                Title = "Sea"
            };

            _bookModelDTOs = new List<BookModelDTO>
            {
                 new BookModelDTO
                 {
                    Id = 2,
                    NameOfAuthor = "Volodya",
                    SureNameOfAuthor = "Khydzik",
                    Title = "Sea"
                },
                new BookModelDTO
                {
                    Id = 2,
                    NameOfAuthor = "Ura",
                    SureNameOfAuthor = "Dub",
                    Title = "Black"
                }
            };

            BookId = 1;

        }

        [Test]
        public async Task GetBookCheckReturnBook_Test()
        {
            _bookService.Setup(service => service.GetBookAsync(BookId)).Returns(async () => { return _bookModelDTO; });

            var result = await _bookController.GetBookItem(BookId);

            Assert.AreEqual(typeof(BookModelDTO), _bookModelDTO.GetType());
        }

        [Test]
        public void GetBookCheckReturnBookIsNull_Test()
        {
            _bookService.Setup(service => service.GetBookAsync(BookId)).Returns(async () => { return null; });

            var ex = Assert.ThrowsAsync<Exception>(() => _bookController.GetBookItem(BookId));

            Assert.AreEqual("Such book is not exist", ex.Message);
        }

        [Test]
        public async Task GetBooksCheckReturnBooks_Test()
        {
            _bookService.Setup(service => service.GetBookItemsAsync()).Returns(async () => { return _bookModelDTOs; });

            var result = await _bookController.GetBooks();

            Assert.AreEqual(typeof(List<BookModelDTO>), _bookModelDTOs.GetType());
        }

        [Test]
        public void GetBooksCheckReturnBooksAreNull_Test()
        {
            _bookService.Setup(service => service.GetBookItemsAsync()).Returns(async () => { return null; });

            var ex = Assert.ThrowsAsync<Exception>(() => _bookController.GetBooks());

            Assert.AreEqual("No books!", ex.Message);
        }

        [Test]
        public async Task UpdateBookCheckReturnBook_Test()
        {
            _bookService.Setup(service => service.UpdateBookAsync(_bookModelDTO)).Returns(async () => { return _bookModelDTO; });

            var result = await _bookController.UpdateBook(_bookModelDTO);

            Assert.AreEqual(typeof(BookModelDTO), _bookModelDTO.GetType());
        }

        [Test]
        public void UpdateBookCheckReturnBookIsNull_Test()
        {
            _bookService.Setup(service => service.UpdateBookAsync(_bookModelDTO)).Returns(async () => { return null; });

            var ex = Assert.ThrowsAsync<Exception>(() => _bookController.UpdateBook(_bookModelDTO));

            Assert.AreEqual("Book is not change!", ex.Message);
        }


        [Test]
        public async Task CreateBookCheckReturnOk_Test()
        {
            _bookService.Setup(service => service.CreateAsync(_bookModelDTO)).Returns(async () => { await Task.CompletedTask; });


            var actionResult = await _bookController.CreateBook(_bookModelDTO);
            var contentResult = actionResult as IStatusCodeActionResult;

            Assert.AreEqual(StatusCodes.Status200OK, contentResult.StatusCode);
        }

        [Test]
        public async Task DeleteBookCheckReturnOk_Test()
        {
            _bookService.Setup(service => service.DeleteBookAsync(BookId)).Returns(async () => { await Task.CompletedTask; });
            

            var actionResult = await _bookController.DeleteBook(BookId);
            var contentResult = actionResult as IStatusCodeActionResult;

            Assert.AreEqual(StatusCodes.Status200OK, contentResult.StatusCode);
        }
    }
}
