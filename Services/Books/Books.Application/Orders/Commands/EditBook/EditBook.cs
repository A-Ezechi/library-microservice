using System.Data;
using FluentValidation;
using library_microservice.Services.Books.Books.Domain.Models;
using library_MicroService.BuildingBlocks.CQRS;

namespace library_microservice.Services.Books.Books.Application.Orders.Commands.EditBook
{
    public record EditBookCommand(BookModel Book)
        : ICommand<EditBookResult>;

    public record EditBookResult(BookModel Book, bool IsSuccess, string Message);

    public class EditBookValidator : AbstractValidator<EditBookCommand>
    {
        public EditBookValidator()
        {
            RuleFor(x => x.Book.Id)
                .NotNull()
                .WithMessage("Book ID cannot be null");
        }
    }
}