using library_microservice.Services.Books.Books.Domain.Exceptions;
using library_MicroService.BuildingBlocks.CQRS;
using Marten;

namespace library_microservice.Services.Books.Books.Application.Orders.Commands.DeleteBook
{
    public class DeleteBookHandler(IDocumentSession session, ILogger<DeleteBookHandler> logger) 
        : ICommandHandler<DeleteBookCommand, DeleteBookResponse>
    {
        public async Task<DeleteBookResponse> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var deletedBook = await session
                .Query<DeleteBookCommand>()
                .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken) ?? throw new NotFoundException(command.Id);

            session.Delete(deletedBook);
            logger.LogInformation("Book with ID {Id} deleted", command.Id);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteBookResponse(true, "Book deleted successfully");
        }

        private async Task DeleteBook()
        {
            var deletedBook = await session
                .Query<DeleteBookCommand>()
                .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken) ?? throw new NotFoundException(command.Id);
        }
    }
}