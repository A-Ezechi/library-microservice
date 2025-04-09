using library_microservice.Services.Books.Books.Domain.Models;
using library_MicroService.BuildingBlocks.CQRS;

namespace library_microservice.Services.Books.Books.Application.Orders.Queries.GetBooks
{
    public record GetBoooksQuery() //Add Pagination later
        : IQuery<GetBooksResponse>;

    public record GetBooksResponse(IEnumerable<BookModel> Books);
}