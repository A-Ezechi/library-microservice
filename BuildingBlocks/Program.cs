public partial class Program
{
	public static void BuildingBlocksMain(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		app.MapGet("/", () => "Hello World!");

		app.Run();
	}
}
