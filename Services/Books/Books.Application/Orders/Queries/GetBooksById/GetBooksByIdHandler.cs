using library_microservice.BuildingBlocks.Exceptions.Books;
using library_microservice.Services.Books.Books.Domain.Exceptions;
using library_microservice.Services.Books.Books.Infrastructure.Data;
using library_MicroService.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;

namespace library_microservice.Services.Books.Books.Application.Orders.Queries.GetBooksById
{
    public record GetBooksByIdQueryHandler(LibraryDbContext Context) : IQueryHandler<GetBooksByIdQuery, GetBooksByIdResponse>
    {
        public async Task<GetBooksByIdResponse> Handle(GetBooksByIdQuery query, CancellationToken cancellationToken)
        {
            var book = await Context.Books
                .FirstOrDefaultAsync(x => x.Id.Value == query.Id, cancellationToken) ?? throw new NotFoundException(query.Id);

            return new GetBooksByIdResponse(book);
        }
    }
}   