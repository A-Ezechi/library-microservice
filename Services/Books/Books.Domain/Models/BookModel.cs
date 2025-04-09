using library_microservice.Services.Books.Books.Domain.ValueObjects;

namespace library_microservice.Services.Books.Books.Domain.Models
{
    public class BookModel
    {
        public required BookId Id { get; set; }
        public required string Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; } // Change this to accept a choice of genres and not just a string
        public DateOnly PublishDate { get; set; }
        public int? EditionNumber { get; set; }
        public string? ISBN { get; set; }

        public static BookModel Create(BookId bookId, string title, string author, string genre, DateOnly publishDate, int? editionNumber, string isbn)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));

            return new BookModel
            {
                Id = bookId,
                Title = title,
                Author = author,
                Genre = genre,
                PublishDate = publishDate,
                EditionNumber = editionNumber,
                ISBN = isbn
            };
        }

        public void Update(BookId bookId, string title, string author, string genre, DateOnly publishDate, int? editionNumber, string isbn)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));

            Id = bookId;
            Title = title;
            Author = author;
            Genre = genre;
            PublishDate = publishDate;
            EditionNumber = editionNumber;
            ISBN = isbn;
        }
    }
}