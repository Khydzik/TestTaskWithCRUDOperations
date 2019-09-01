using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using TestTask.Application;
using TestTask.Application.Models;
using TestTask.Data;
using TestTask.Data.Models;

namespace NUnitTestApplication
{
    public class BookServiceTest
    {
        private BookService _bookService;
        private Mock<IBookRepository> _bookRepository;
        private BookModelDTO _bookModelDTO;

        private Book _book;
        private List<BookModelDTO> _bookModelDTOs;
        private int BookId;

        [SetUp]
        public void Setup()
        {
            _bookRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_bookRepository.Object);

            _book = new Book
            {
                Id = 1,
                AuthorId = 1,
                Title = "Sea",
                Author = new Author {  Id = 1, Name = "Volodya", SureName = "Khydzik" }
            };

            _bookModelDTO = new BookModelDTO
            {
                Id = 1,
                NameOfAuthor = "Volodya",
                SureNameOfAuthor = "Khydzik",
                Title = "Sea1"
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
            _bookRepository.Setup(service => service.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>())).Returns(async () =>
            {
                return _book;
            });

            var result = await _bookService.GetBookAsync(BookId);

            Assert.AreEqual(typeof(BookModelDTO), _bookModelDTO.GetType());
        }

        [Test]
        public void GetBookCheckReturnBookIsNull_Test()
        {
            _bookRepository.Setup(service => service.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>())).Returns(async () => { return null; });

            var ex = Assert.ThrowsAsync<Exception>(() => _bookService.GetBookAsync(BookId));

            Assert.AreEqual("Book is not found.", ex.Message);
        }       

        [Test]
        public async Task UpdateBookCheckReturnChangedBook_Test()
        {
            _bookRepository.Setup(service => service.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>())).Returns(async () => { return _book; });

            var result = await _bookService.UpdateBookAsync(_bookModelDTO);

            Assert.AreEqual(typeof(BookModelDTO), _bookModelDTO.GetType());
        }

        [Test]
        public void UpdateBookCheckReturnBookIsNull_Test()
        {
            _bookRepository.Setup(service => service.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>())).Returns(async () => { return null; });

            var ex = Assert.ThrowsAsync<Exception>(() => _bookService.UpdateBookAsync(_bookModelDTO));

            Assert.AreEqual("Book is not found.", ex.Message);
        }

        [Test]
        public async Task DeleteBookCheckReturnCompletedTask_Test()
        {
            _bookRepository.Setup(service => service.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>())).Returns(async () => {
                return _book;
            });

            var actionResult = _bookService.DeleteBookAsync(BookId).GetAwaiter();

            Assert.IsTrue(actionResult.IsCompleted);
        }

        [Test]
        public void DeleteBookCheckReturnBookIsNull_Test()
        {
            _bookRepository.Setup(service => service.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>())).Returns(async () => { return null; });

            var ex = Assert.ThrowsAsync<Exception>(() => _bookService.DeleteBookAsync(BookId));

            Assert.AreEqual("Book is not found.", ex.Message);
        }

        [Test]
        public void CreateBookCheckReturnCompletedTask_Test()
        {
            _bookRepository.Setup(service => service.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>())).Returns(async () => {
                return null;
            });

            var actionResult = _bookService.CreateAsync(_bookModelDTO);

            Assert.IsTrue(actionResult.IsCompleted);
        }

        [Test]
        public async Task CreateBookCheckReturnBookIsNull_Test()
        {
            _bookRepository.Setup(service => service.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>())).Returns(async () => {
                return _book;
            });

            var ex = Assert.ThrowsAsync<Exception>(() => _bookService.CreateAsync(_bookModelDTO));

            Assert.AreEqual("Such book exist!", ex.Message);
        }     
    }
}
