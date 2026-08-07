using DemoFileStorage.Services;
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

        var fileShareService = new FileShareService(connectionString);

        // Create dynamic file name
        string fileName =
            $"Sample_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

        await File.WriteAllTextAsync(
            fileName,
            $"File created at {DateTime.Now}");

        Console.WriteLine($"Created File: {fileName}");

        // Upload File
        Console.WriteLine("\nUploading File:");
        await fileShareService.UploadFileAsync(fileName);

        // Download File
        string downloadPath = $"Downloaded_{fileName}";

        Console.WriteLine("\nDownloading File:");
        await fileShareService.DownloadFileAsync(
            fileName,
            downloadPath);

        Console.WriteLine("\nFile Share operation completed.");
    }
}