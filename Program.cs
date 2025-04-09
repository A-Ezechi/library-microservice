using library_microservice.Services.Books.Books.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public partial class Program
{
	public static void Main(string[] args)
	{
        // Register Services
        
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		builder.Services.AddDbContext<LibraryDbContext>(options =>
			options.UseNpgsql(builder.Configuration.GetConnectionString("LibraryConnection")));

		// Register Marten

        // Start the service

		app.Run();
	}
}
