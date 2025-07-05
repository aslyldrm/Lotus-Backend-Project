using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Features
{
    public class AzureBlobForPregnancyPictures
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "pregnancypictures";

        public AzureBlobForPregnancyPictures(BlobServiceClient blobServiceClient)
        {
          //  _blobServiceClient = new BlobServiceClient(connectionString);
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> GetFileUrlAsync(string blobName)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = blobContainerClient.GetBlobClient(blobName);

            if (await blobClient.ExistsAsync())
            {
                return blobClient.Uri.ToString();
            }
            else
            {
                throw new FileNotFoundException($"Blob '{blobName}' not found.");
            }
        }
    }
}
