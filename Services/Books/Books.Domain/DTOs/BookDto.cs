namespace library_microservice.Services.Books.Books.Domain.DTOs
{
    public record BookDto(
        Guid Id, 
        string Title, 
        string Author, 
        string Description, 
        string ISBN, 
        int Year, 
        decimal Price
    );
}