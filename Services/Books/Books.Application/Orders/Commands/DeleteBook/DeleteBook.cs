using FluentValidation;
using library_MicroService.BuildingBlocks.CQRS;
using MediatR;

namespace library_microservice.Services.Books.Books.Application.Orders.Commands.DeleteBook
{
    public record DeleteBookCommand(Guid Id) : ICommand<DeleteBookResponse>;
    public record DeleteBookResponse(bool IsDeleted, string Message);

    public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid number");
        }
    }
}