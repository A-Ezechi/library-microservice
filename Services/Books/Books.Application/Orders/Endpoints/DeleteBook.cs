

using Carter;
using Mapster;
using MediatR;

namespace library_microservice.Services.Books.Books.Application.Orders.Endpoints
{
    public record DeleteBookResponse(bool IsDeleted, string Message);

    public class DeleteBookEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/books/{id:guid}", async (Guid Id, ISender Sender) =>
            {
                var book = await Sender.Send(Id);
                var response = book.Adapt<DeleteBookResponse>();
                return Results.Ok(response);
            })
            .WithName("DeleteBook")
            .WithDescription("Delete a book by id")
            .Produces<DeleteBookResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }
}