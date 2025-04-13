using Carter;
using library_microservice.Services.Books.Books.Domain.Models;
using library_microservice.Services.Books.Books.Application.Orders.Commands.EditBook;
using Mapster;
using MediatR;

namespace library_MicroService.Services.Books.Books.Application.Orders.Endpoints
{
    public record EditBookRequest(BookModel Book);
    public record EditBookResponse(bool IsSuccess);

    public class EditBookEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/books/{Id : Guid}", async (ISender Sender, EditBookRequest Request) =>
            {
                var command = Request.Book.Adapt<EditBookCommand>();
                var result = await Sender.Send(command);
                var response = result.Adapt<EditBookResponse>();

                return Results.Ok(response);
            })
            .WithName("EditBook")
            .WithDescription("Edit a book")
            .Produces<EditBookResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }

}