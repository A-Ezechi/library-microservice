using library_microservice.BuildingBlocks.Exceptions.Books;
using library_microservice.Services.Books.Books.Domain.Models;
using library_microservice.Services.Books.Books.Domain.ValueObjects;

namespace library_microservice.Services.Books.Books.Domain.Exceptions
{
    public class NotFoundException : BookNotFoundException
    {
        public NotFoundException(Guid Id) : base($"Product with id {Id} was not found", Id)
        {
        }
    }
}