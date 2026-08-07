using Microsoft.Extensions.Configuration;
using BlobSrviceDemo.Services;

class Program
{
    static async Task Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory()) --Need to do platform independant make change in csproj
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config["ConnectionStrings:cs"]!;

        var blobService = new BlobService(connectionString);

        // Create sample.txt
        string sampleFile = $"Sample_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        
        await File.WriteAllTextAsync(
            sampleFile,
            "Hello from Azure Blob Storage Demo!");

        Console.WriteLine("Created sample.txt");

        // Upload
        await blobService.UploadBlobAsync(sampleFile);

        // List blobs
        Console.WriteLine("\nListing blobs:");
        await blobService.ListBlobsAsync();

        // Download
        string downloadPath = "downloaded-sample.txt";

        await blobService.DownloadBlobAsync(
            sampleFile,
            downloadPath);

        Console.WriteLine("\nDownload completed.");
    }
}