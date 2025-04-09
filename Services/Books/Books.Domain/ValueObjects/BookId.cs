using library_microservice.BuildingBlocks.Exceptions.Books;
using library_microservice.Services.Books.Books.Domain.Exceptions;

namespace library_microservice.Services.Books.Books.Domain.ValueObjects
{
    public record BookId
    {
        public Guid Value { get; }

        public BookId(Guid value) => Value = value;

        public static BookId Of(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new NotFoundException(value);
            }
            
            return new BookId(value);
        }
    }
}