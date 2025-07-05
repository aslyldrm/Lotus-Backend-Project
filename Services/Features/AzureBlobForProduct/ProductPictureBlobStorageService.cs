using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;

namespace WebApi.Utilities.AzureBlobForProduct
{
    public class ProductPictureBlobStorageService
    {
       
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "lotusproductpictures";


        public ProductPictureBlobStorageService(BlobServiceClient blobServiceClient)
        {
         
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadBlobAsync(Stream fileStream, string blobName)
        {
            var uniqueBlobName = $"{Guid.NewGuid()}_{blobName}";

            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(uniqueBlobName);

            // Check if the blob exists and delete it if it does
            if (await blobClient.ExistsAsync())
            {
                await blobClient.DeleteAsync();
            }

            // Upload the new file
            await blobClient.UploadAsync(fileStream, true);
            return blobClient.Uri.ToString();
        }
       
        public async Task DeleteBlobAsync(string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            try
            {
                // Blob'un var olup olmadığını kontrol edelim
                var blobExists = await blobClient.ExistsAsync();

                if (!blobExists.Value)
                {
                    Console.WriteLine($"Blob '{blobName}' not found or already deleted.");
                    return; // Eğer blob bulunmazsa silme işlemi yapılmaz
                }

                // Blob'u silme işlemi
                Console.WriteLine($"Attempting to delete blob '{blobName}'...");
                var response = await blobClient.DeleteIfExistsAsync();

                if (response.Value)
                {
                    Console.WriteLine($"Blob '{blobName}' successfully deleted.");
                }
                else
                {
                    Console.WriteLine($"Failed to delete blob '{blobName}'.");
                }
            }
            catch (Azure.RequestFailedException ex)
            {
                Console.WriteLine($"Error deleting blob: {ex.Message}");
                throw;
            }
           
        }

        public async Task<Stream> GetBlobAsync(string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

            // Ensure blobName is trimmed and correct
            blobName = blobName?.Trim();

            // Check if blobName is valid
            if (string.IsNullOrEmpty(blobName))
            {
            
                return null;
            }

            var blobClient = containerClient.GetBlobClient(blobName);

         

            var blobDownloadInfo = await blobClient.DownloadAsync();
            return blobDownloadInfo.Value.Content;



            
        }

        public async Task<string> UpdateBlobAsync(Stream fileStream, string blobName)
        {
            await DeleteBlobAsync(blobName);  // Önce mevcut dosyayı sil
            return await UploadBlobAsync(fileStream, blobName);  // Sonra yeni dosyayı yükle
        }


      

       
    }
}
