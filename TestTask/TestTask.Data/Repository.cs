using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestTask.Data.Models;

namespace TestTask.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly DbContext _dbContext;

        public BookRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Book> Query()
        {
            return _dbContext.Set<Book>().Include(item => item.Author);
        }

        public IEnumerable<Book> Insert(IEnumerable<Book> entities)
        {
            _dbContext.AddRange(entities);

            _dbContext.SaveChanges();

            return entities;
        }

        public async Task<IEnumerable<Book>> InsertAsync(IEnumerable<Book> entities)
        {
            await _dbContext.AddRangeAsync(entities);

            await _dbContext.SaveChangesAsync();

            return entities;
        }

        public Book Insert(Book entity)
        {
            _dbContext.Add(entity);

            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<Book> InsertAsync(Book entity)
        {
            await _dbContext.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public Book Update(Book entity)
        {
            _dbContext.Update(entity);

            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            _dbContext.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public IEnumerable<Book> Update(IEnumerable<Book> entities)
        {
            _dbContext.UpdateRange(entities);

            _dbContext.SaveChanges();

            return entities;
        }

        public async Task<IEnumerable<Book>> UpdateAsync(IEnumerable<Book> entities)
        {
            _dbContext.UpdateRange(entities);

            await _dbContext.SaveChangesAsync();

            return entities;
        }

        public async Task<Book> GetAsync(Expression<Func<Book, bool>> predicate)
        {
            return await _dbContext.Set<Book>().Include(item => item.Author).FirstOrDefaultAsync(predicate);
        }

        public Book Delete(Book entity)
        {
            _dbContext.Remove(entity);

            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<Book> DeleteAsync(Book entity)
        {
            _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
