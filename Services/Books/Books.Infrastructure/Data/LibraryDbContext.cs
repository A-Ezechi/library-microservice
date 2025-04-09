namespace library_microservice.Services.Books.Books.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using library_microservice.Services.Books.Books.Domain.Models;

    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<BookModel> Books => Set<BookModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>().HasKey(b => b.Id);
        }
    }
}