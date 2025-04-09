using FluentValidation;
using library_microservice.Services.Books.Books.Domain.Models;
using library_MicroService.BuildingBlocks.CQRS;

namespace library_microservice.Services.Books.Books.Application.Orders.Commands.AddBook
{
    public record AddBookCommand(BookModel Command) 
        : ICommand<AddBookResponse>;

    public record AddBookResponse(bool IsSuccess, Guid BookId, string Message);

    public class AddBookValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookValidator()
        {
            RuleFor(x => x.Command.Id).NotEmpty().WithMessage("Book Id is required");
            RuleFor(x => x.Command.Title).NotNull().WithMessage("Book Title is required");
        }
    }
}