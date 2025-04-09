using library_microservice.Services.Books.Books.Domain.ValueObjects;
using Microsoft.AspNetCore.Diagnostics;

namespace library_microservice.BuildingBlocks.Exceptions.Books
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string message, Guid id) : base()
        {
        }
    }
}