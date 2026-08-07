using Azure.Storage.Blobs;
namespace BlobSrviceDemo.Services
{
    public class BlobService
    {
        private readonly string _connectionString;
        private const string ContainerName = "documents";

        public BlobService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task UploadBlobAsync(string localFilePath)
        {
            BlobContainerClient container =
                new BlobContainerClient(_connectionString, ContainerName);

            await container.CreateIfNotExistsAsync();

            string fileName = Path.GetFileName(localFilePath);

            BlobClient blobClient =
                container.GetBlobClient(fileName);

            await blobClient.UploadAsync(localFilePath, overwrite: true);

            Console.WriteLine($"Uploaded Blob: {fileName}");
        }

        public async Task DownloadBlobAsync(
            string blobName,
            string downloadPath)
        {
            BlobContainerClient container =
                new BlobContainerClient(_connectionString, ContainerName);

            BlobClient blobClient =
                container.GetBlobClient(blobName);

            await blobClient.DownloadToAsync(downloadPath);

            Console.WriteLine($"Downloaded Blob: {downloadPath}");
        }

        public async Task ListBlobsAsync()
        {
            BlobContainerClient container =
                new BlobContainerClient(_connectionString, ContainerName);

            await foreach (var blob in container.GetBlobsAsync())
            {
                Console.WriteLine(blob.Name);
            }
        }
    }
}