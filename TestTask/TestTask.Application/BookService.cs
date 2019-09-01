using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Application.Models;
using TestTask.Data;
using TestTask.Data.Models;

namespace TestTask.Application
{
    public class BookService:IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookModelDTO>> GetBookItemsAsync()
        {
            var listBooks = await _bookRepository.Query().ToListAsync();

            if (listBooks == null)
                throw new Exception("Books are not exist!");

            var result = from book in listBooks select new BookModelDTO
            {
                Id = book.Id,
                Title = book.Title,
                NameOfAuthor = book.Author.Name,
                SureNameOfAuthor = book.Author.SureName
            };

            return result;
        }      

        public async Task CreateAsync(BookModelDTO bookModel)
        {
            var book = await _bookRepository.GetAsync(u => u.Title == bookModel.Title);

            if (book != null)
                throw new Exception("Such book exist!");

            var newBook = new Book
            {
              Title = bookModel.Title,
              Author = new Author { Name = bookModel.NameOfAuthor, SureName = bookModel.SureNameOfAuthor }
            };

            await _bookRepository.InsertAsync(newBook);
        }

        public async Task<BookModelDTO> UpdateBookAsync(BookModelDTO input)
        {
            var book = await _bookRepository.GetAsync(u => u.Id == input.Id);

            if (book == null)
            {
                throw new Exception("Book is not found.");
            }

            book.Title = input.Title ?? book.Title;

            book.Author.Name= input.NameOfAuthor ?? book.Author.Name;

            book.Author.SureName = input.SureNameOfAuthor ?? book.Author.SureName;

            await _bookRepository.UpdateAsync(book);

            return input;
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = await _bookRepository.GetAsync(u => u.Id == bookId);

            if (book == null)
            {
                throw new Exception("Book is not found.");
            }

            await _bookRepository.DeleteAsync(book);
        }

        public async Task<BookModelDTO> GetBookAsync(int bookId)
        {
            var book = await _bookRepository.GetAsync(u => u.Id == bookId);

            if (book == null)
            {
                throw new Exception("Book is not found.");
            }

            return new BookModelDTO { Title = book.Title, NameOfAuthor = book.Author.Name, SureNameOfAuthor = book.Author.SureName };
        }
    }
}
