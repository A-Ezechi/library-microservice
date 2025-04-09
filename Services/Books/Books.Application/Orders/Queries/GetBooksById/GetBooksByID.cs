using library_MicroService.BuildingBlocks.CQRS;

using FluentValidation;
using library_microservice.Services.Books.Books.Domain.Models;

namespace library_microservice.Services.Books.Books.Application.Orders.Queries.GetBooksById
{
   public record GetBooksByIdQuery(Guid Id)
    :IQuery<GetBooksByIdResponse>;

    public record GetBooksByIdResponse(BookModel Books);

    public class GetBooksByIdQueryValidator : AbstractValidator<GetBooksByIdQuery>
    {
        public GetBooksByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}