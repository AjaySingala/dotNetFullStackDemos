//install-package Azure.Storage.Blobs
// Set env var "AZURE_STORAGE_CONNECTION_STRING".

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;

namespace AzureBlobDemo
{
    internal class Program
    {
        static string localFilePath = "";
        static string downloadFilePath = "";

        static async Task Main(string[] args)
        {
            var connectionString = GetAzureStorageConnectionString();

            // Create a BlobServiceClient object 
            var blobServiceClient = new BlobServiceClient(connectionString);
            var taskBlobContainerClient = CreateBlobContainer(blobServiceClient);
            var blobContainerClient = taskBlobContainerClient.Result;
            var blobClient = await UploadBlobToContainer(blobContainerClient);
            await ListBlobsInAContainers(blobContainerClient);
            await DownloadBlob(blobClient);
            
            Console.WriteLine("Check the downloaded file and on Azure Storage.");
            Console.WriteLine("Press <ENTER> to continue to DELETE the container and local files...");
            Console.ReadLine();

            await DeleteContainer(blobContainerClient);
            Console.WriteLine("Done!");
        }

        static string GetAzureStorageConnectionString()
        {
            // Retrieve the connection string for use with the application. 
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            return connectionString;
        }

        static async Task<BlobContainerClient> CreateBlobContainer(BlobServiceClient blobServiceClient)
        {
            //// TODO: Replace <storage-account-name> with your actual storage account name
            //var blobServiceClient = new BlobServiceClient(
            //        new Uri("https://<storage-account-name>.blob.core.windows.net"),
            //        new DefaultAzureCredential());

            //Create a unique name for the container
            string containerName = "quickstartblobs" + Guid.NewGuid().ToString();

            // Create the container and return a container client object
            BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
            return containerClient;
        }

        static async Task<BlobClient> UploadBlobToContainer(BlobContainerClient containerClient)
        {
            // Create a local file in the ./data/ directory for uploading and downloading
            string localPath = "data";
            Directory.CreateDirectory(localPath);
            string fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
            localFilePath = Path.Combine(localPath, fileName);

            // Write text to the file
            await File.WriteAllTextAsync(localFilePath, "Hello, World!");

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

            // Upload data from the local file
            await blobClient.UploadAsync(localFilePath, true);
            return blobClient;
        }

        static async Task ListBlobsInAContainers(BlobContainerClient containerClient)
        {
            Console.WriteLine($"Listing blobs in container {containerClient.Name}...");

            // List all blobs in the container
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                Console.WriteLine("\t" + blobItem.Name);
            }
        }

        static async Task DownloadBlob(BlobClient blobClient)
        {
            // Download the blob to a local file
            // Append the string "DOWNLOADED" before the .txt extension 
            // so you can compare the files in the data directory
            downloadFilePath = localFilePath.Replace(".txt", "DOWNLOADED.txt");

            Console.WriteLine("\nDownloading blob to\n\t{0}\n", downloadFilePath);

            // Download the blob's contents and save it to a file
            await blobClient.DownloadToAsync(downloadFilePath);
        }

        static async Task DeleteContainer(BlobContainerClient containerClient)
        {
            // Clean up
            Console.Write("Press any key to begin clean up");
            Console.ReadLine();

            Console.WriteLine("Deleting blob container...");
            await containerClient.DeleteAsync();

            Console.WriteLine("Deleting the local source and downloaded files...");
            File.Delete(localFilePath);
            File.Delete(downloadFilePath);
        }
    }
}