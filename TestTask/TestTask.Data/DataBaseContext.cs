using Microsoft.EntityFrameworkCore;
using TestTask.Data.Models;

namespace TestTask.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {        
        }
    }
}
