using library_MicroService.BuildingBlocks.CQRS;
using library_microservice.Services.Books.Books.Domain.Exceptions;
using Marten;
using library_microservice.Services.Books.Books.Domain.Models;

namespace library_microservice.Services.Books.Books.Application.Orders.Commands.EditBook
{
    public class EditBookHandler(IDocumentSession session) 
        : ICommandHandler<EditBookCommand, EditBookResult>
    {
        public async Task<EditBookResult> Handle(EditBookCommand command, CancellationToken cancellationToken)
        {
            // Check if the book exists

            var Book = await session.LoadAsync<BookModel>(command.Book.Id, cancellationToken);

            if (Book == null)
            {
                return new EditBookResult(default, false, "Book not found");
                throw new NotFoundException(command.Book.Id.Value);
            }
            
            // Update the book details

            Book.Id = command.Book.Id;
            Book.Title = command.Book.Title;
            Book.Author = command.Book.Author;
            Book.Genre = command.Book.Genre;
            Book.PublishDate = command.Book.PublishDate;
            Book.EditionNumber = command.Book.EditionNumber;
            Book.ISBN = command.Book.ISBN;

            session.Update(Book);
            await session.SaveChangesAsync(cancellationToken);
            return new EditBookResult(Book, true, "Book updated successfully");
        }
    }
}