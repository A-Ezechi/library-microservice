using library_microservice.Services.Books.Books.Domain.Models;
using Carter;
using MediatR;
using Mapster;
using library_microservice.Services.Books.Books.Application.Orders.Commands.AddBook;

namespace library_microservice.Services.Books.Books.Application.Orders.Endpoints
{
    public record CreateBookResponse(bool IsSuccess, Guid BookId, string Message);

    public class CreateBookEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/books", async (BookModel book, ISender sender) =>
            {
                var newBook = book.Adapt<AddBookCommand>();
                var result = await sender.Send(newBook);
                var response = new CreateBookResponse(result.IsSuccess, result.BookId, result.Message);

                return result.IsSuccess ? Results.Created($"/books/{result.BookId}", response) : Results.BadRequest(response);
            })
            .WithName("CreateBook")
            .Produces<CreateBookResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithTags("Books");
        }
    }
}