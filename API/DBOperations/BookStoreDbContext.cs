using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options): base(options)
        {
        }
        public DbSet<Book> Books { get; set;}
        public DbSet<Category> Category { get; set; }
        public DbSet<Author> Author { get; set; }
    }
}