
using MediatR;
using library_microservice.Services.Books.Books.Application.Orders.Queries.GetBooks;
using Carter;
using Mapster;
using library_microservice.Services.Books.Books.Domain.Models;

namespace library_microservice.Services.Books.Books.Application.Orders.Endpoints
{
    public record GetBooksResponse(BookModel Book);

    public class GetBooks : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/books", async (ISender sender) =>
            {
                var query = await sender.Send(new GetBooksQuery());
                var response = query.Adapt<GetBooksResponse>();
                return Results.Ok(response);
            })
            .WithName("GetBooks")
            .WithDescription("Get all books")
            .Produces<GetBooksResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }
}