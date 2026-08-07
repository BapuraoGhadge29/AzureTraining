using DemoTableStorage.Services;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config["ConnectionStrings:cs"]!;

        var tableStorageService =
            new TableStorageService(connectionString);

        Console.WriteLine("Adding Employee...");

        await tableStorageService.AddEmployeeAsync();

        Console.WriteLine("\nFetching Employees...");

        await tableStorageService.GetEmployeesAsync();

        Console.WriteLine("\nTable Storage operations completed.");
    }
}