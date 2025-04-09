using Microsoft.EntityFrameworkCore;
using library_microservice.Services.Books.Books.Domain.Models;

namespace library_microservice.Services.Books.Books.Application.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<BookModel> Books { get; set; }
    }
}