
using MediatR;
using Carter;
using Mapster;
using library_microservice.Services.Books.Books.Domain.Models;
using library_microservice.Services.Books.Books.Application.Orders.Queries.GetBooksById;

namespace library_microservice.Services.Books.Books.Application.Orders.Endpoints
{
    public record GetBookByIdResponse(BookModel Book);

    public class GetBookById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/books/{Id}", async (Guid Id, ISender Sender) =>
            {
                var query = await Sender.Send(new GetBooksByIdQuery(Id));
                var response = query.Adapt<GetBooksByIdResponse>();
                return Results.Ok(response);
            })
            .WithName("GetBookById")
            .WithDescription("Get a book by id")
            .Produces<GetBooksResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }
}