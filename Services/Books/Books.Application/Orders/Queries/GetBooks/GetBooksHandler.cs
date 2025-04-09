using library_microservice.Services.Books.Books.Application.Orders.Queries.GetBooksById;
using library_microservice.Services.Books.Books.Infrastructure.Data;
using library_MicroService.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;

namespace library_microservice.Services.Books.Books.Application.Orders.Queries.GetBooks
{
    public class GetBooksHandler(LibraryDbContext context) : IQueryHandler<GetBoooksQuery, GetBooksResponse>
    {
        public async Task<GetBooksResponse> Handle(GetBoooksQuery query, CancellationToken cancellationToken)
        {
            var books = await context.Books
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync(cancellationToken);

            return new GetBooksResponse(books);
        }
    }
}