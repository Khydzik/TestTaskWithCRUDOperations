using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestTask.Data.Models;

namespace TestTask.Data
{
    public interface IBookRepository
    {
        Book Delete(Book entity);
        Task<Book> DeleteAsync(Book entity);
        Task<Book> GetAsync(Expression<Func<Book, bool>> predicate);
        IEnumerable<Book> Insert(IEnumerable<Book> entities);
        Book Insert(Book entity);
        Task<IEnumerable<Book>> InsertAsync(IEnumerable<Book> entities);
        Task<Book> InsertAsync(Book entity);
        IQueryable<Book> Query();
        IEnumerable<Book> Update(IEnumerable<Book> entities);
        Book Update(Book entity);
        Task<IEnumerable<Book>> UpdateAsync(IEnumerable<Book> entities);
        Task<Book> UpdateAsync(Book entity);
    }
}
