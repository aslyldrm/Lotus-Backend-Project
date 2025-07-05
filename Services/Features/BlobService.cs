using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Features
{

    
        public class BlobService
        {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "lotusprojectpodcasts";

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadFileForPodcastAsync(IFormFile file)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

                // Benzersiz dosya adı oluşturma
                var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
                var blobClient = containerClient.GetBlobClient(uniqueFileName);
                using (var stream = file.OpenReadStream())
                {
                    Uri str = blobClient.Uri;
                    await blobClient.UploadAsync(stream, true);
                }

                return blobClient.Uri.ToString();
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                // Gerekli hata günlüğü işlemleri burada yapılabilir
                throw new Exception("Dosya yükleme sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteFileAsync(string fileName)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                var blobClient = containerClient.GetBlobClient(fileName);
                await blobClient.DeleteIfExistsAsync();
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                // Gerekli hata günlüğü işlemleri burada yapılabilir
                throw new Exception("Dosya silme sırasında bir hata oluştu.", ex);
            }

        }
    }

    }

