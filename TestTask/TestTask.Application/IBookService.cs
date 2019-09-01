using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Application.Models;

namespace TestTask.Application
{
    public interface IBookService
    {
        Task<IEnumerable<BookModelDTO>> GetBookItemsAsync();
        Task CreateAsync(BookModelDTO bookModel);
        Task<BookModelDTO> UpdateBookAsync(BookModelDTO input);
        Task DeleteBookAsync(int bookId);
        Task<BookModelDTO> GetBookAsync(int bookId);
    }
}
