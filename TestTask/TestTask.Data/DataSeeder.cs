using System.Threading.Tasks;
using TestTask.Data.Models;

namespace TestTask.Data
{
    public class DataSeeder
    {
        private readonly IBookRepository _bookRepository;
        public DataSeeder(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Seed()
        {
            var book = new Book
            {
                Title = "The Old Man and the Sea",
                Author = new Author { Name = "Ernest", SureName = "Hemingway" }
            };

            if (await _bookRepository.GetAsync(title => title.Title == book.Title).ConfigureAwait(false) == null)
            {
                var result = await _bookRepository.InsertAsync(book);
            }
        }
    }
}
