

using library_microservice.Services.Books.Books.Domain.Models;

namespace library_microservice.Services.Books.Books.Application.Orders.Endpoints
{
    public record GetBooksResponse(BookModel Book);
}