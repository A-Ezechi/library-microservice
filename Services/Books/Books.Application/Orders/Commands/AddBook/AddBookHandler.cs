using library_microservice.Services.Books.Books.Domain.Models;
using library_MicroService.BuildingBlocks.CQRS;
using Marten;

namespace library_microservice.Services.Books.Books.Application.Orders.Commands.AddBook
{
    internal class AddBookHandler : ICommandHandler<AddBookCommand, AddBookResponse>
    {
        private readonly IDocumentSession session;

        public AddBookHandler(IDocumentSession session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }

        /// <summary>
        /// Handles the addition of a new book to the library.
        /// </summary>
        /// 
        /// <param name="command">The command containing the details of the book to be added.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An <see cref="AddBookResponse"/> indicating the success or failure of the operation.</returns>
        
        public async Task<AddBookResponse> Handle(AddBookCommand command, CancellationToken cancellationToken)
        {

            // Check if the book already exists
            var existingBook = await session.Query<Guid>()
                .FirstOrDefaultAsync(x => x == command.Command.Id.Value, cancellationToken);

            if (existingBook != default) return new AddBookResponse(false, default, "Book already exists");

            // Create the book

            var newBook = BookModel.Create(
                command.Command.Id,
                command.Command.Title,
                command.Command.Author,
                command.Command.Genre,
                command.Command.PublishDate,
                command.Command.EditionNumber,
                command.Command.ISBN  
            );

            try
            {
                session.Store(newBook);
                await session.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new AddBookResponse(false, default, $"An error occurred while storing the book: {ex.Message}");
            }

            return new AddBookResponse(true, newBook.Id.Value, "Book added successfully");
        }
    }
}