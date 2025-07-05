using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Azure.Storage;
using Entities.DataTransferObjects.Article;
using Entities.DataTransferObjects.Podcast;
using Entities.DataTransferObjects.Product;
using Entities.Exceptions.Article;
using Entities.Exceptions.Podcast;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Features;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.DataTransferObjects.ForumAnswers;
using Entities.DataTransferObjects.ForumQuestion;
using Entities.RequestFeatures;
using Entities.DataTransferObjects.Forum;

namespace Services
{
    public class PodcastManager : IPodcastService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly BlobService _blobService;

        public PodcastManager(IRepositoryManager manager, BlobService blobService)
        {
            _manager = manager;
        
            _blobService = blobService;
        }

        public async Task<IEnumerable<Podcast>> GetAllAsync(bool trackChanges)
        {
            return await _manager.Postcast.GetAllPodcastsAsync(trackChanges);
        }

        public async Task<Podcast> GetByIdAsync(int id)
        {
            return await _manager.Postcast.GetPodcastByIdAsync(id,false);
        }

        public async Task<Podcast> AddAsync(IFormFile file, string title, string description, int podcastCategoryId, IFormFile imageFile)
        {
            var url = await _blobService.UploadFileForPodcastAsync(file);
            var imageUrl = await UploadImageToBlobAsync(imageFile);
            var articleCategory = await _manager.ArticleCategory
           .GetOneArticleCategoryAsync(podcastCategoryId,false);

            if (articleCategory == null)
            {
                throw new Exception("Invalid ArticleCategoryId");
            }
            var podcast = new Podcast
            {
                Title = title,
                Description = description,
                Url = url,
                Image = imageUrl,
                PodcastCategoryId = podcastCategoryId


            };
         


            await _manager.Postcast.AddPodcastAsync(podcast);
            await _manager.SaveAsync();
            return podcast;
        }

        public async Task UpdateAsync(int id, string title, string description, string writers, int podcastCategoryId, IFormFile imageFile)
        {
            var podcast = await _manager.Postcast.GetPodcastByIdAsync(id,false);
            
            if (podcast != null)
            {
                if (!string.IsNullOrEmpty(title))
                {
                    podcast.Title = title;
                }

                if (!string.IsNullOrEmpty(description))
                {
                    podcast.Description = description;
                }

                if (!string.IsNullOrEmpty(writers))
                {
                    podcast.Writers = writers;
                }
                if (podcastCategoryId != 0)
                {
                    var articleCategory = await _manager.ArticleCategory
                    .GetOneArticleCategoryAsync(podcastCategoryId, false);

                    if (articleCategory == null)
                    {
                        throw new Exception("Invalid ArticleCategoryId");
                    }
                    podcast.PodcastCategoryId = podcastCategoryId;

                }

                if (imageFile != null && imageFile.Length > 0)
                {
                    // Delete the existing image if there is one
                    if (!string.IsNullOrEmpty(podcast.Image))
                    {
                        await DeleteImageFromBlobAsync(podcast.Image);
                    }

                    podcast.Image = await UploadImageToBlobAsync(imageFile);
                }
                await _manager.Postcast.UpdatePodcastAsync(podcast);
                await _manager.SaveAsync();

            }
        }

        public async Task DeleteAsync(int id)
        {
            var podcast = await _manager.Postcast.GetPodcastByIdAsync(id, false);
            if (podcast != null)
            {
                // Delete the associated image from Azure Blob storage if it exists
                if (!string.IsNullOrEmpty(podcast.Image))
                {
                    await DeleteImageFromBlobAsync(podcast.Image);
                }
                await _manager.Postcast.DeletePodcastAsync(podcast);
                await _manager.SaveAsync();
            }
        }

        private async Task<string> UploadImageToBlobAsync(IFormFile image)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=lotuspodcastpictures;AccountKey=Zc2OT+UJ1H3yB/AoVo17COqehQoxHqxDU2eqTfJjBKh0o66+ZxaRItLhqvywdXToi9uBXCeoZcjZ+AStXiU0uA==;EndpointSuffix=core.windows.net";
            string containerName = "lotuspodcastpictures";

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            await containerClient.CreateIfNotExistsAsync();

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            using (var ms = new MemoryStream())
            {
                await image.CopyToAsync(ms);
                ms.Position = 0;
                await blobClient.UploadAsync(ms, true);
            }

            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            DateTimeOffset utcExpiry = utcNow.AddYears(1); // Adding one year

            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerClient.Name,
                BlobName = blobClient.Name,
                Resource = "b",
                StartsOn = utcNow,
                ExpiresOn = utcExpiry
            };

            sasBuilder.SetPermissions(BlobSasPermissions.Read);

            string sasToken = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(blobServiceClient.AccountName, "Zc2OT+UJ1H3yB/AoVo17COqehQoxHqxDU2eqTfJjBKh0o66+ZxaRItLhqvywdXToi9uBXCeoZcjZ+AStXiU0uA==")).ToString();
            UriBuilder sasUri = new UriBuilder(blobClient.Uri)
            {
                Query = sasToken
            };

            return sasUri.ToString();
        }
        private async Task DeleteImageFromBlobAsync(string imageUrl)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=lotuspodcastpictures;AccountKey=Zc2OT+UJ1H3yB/AoVo17COqehQoxHqxDU2eqTfJjBKh0o66+ZxaRItLhqvywdXToi9uBXCeoZcjZ+AStXiU0uA==;EndpointSuffix=core.windows.net";
            string containerName = "lotuspodcastpictures";

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            Uri uri = new Uri(imageUrl);
            string blobName = Path.GetFileName(uri.LocalPath);

            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }
        public async Task<IEnumerable<Podcast>> GetFilteredPodcastAsync(PodcastFilterParameters podcastParameters, bool trackChanges)
        {
            
            var forums = await _manager.Postcast.GetFilteredPodcastAsync(podcastParameters, trackChanges);
       


            return forums; 
        }
        public async Task<IEnumerable<Podcast>> SearchPodcastsByTitleAsync(string title, bool trackChanges)
        {
            var podcastsQuery = _manager.Postcast.FindAll(trackChanges);

            if (!string.IsNullOrWhiteSpace(title))
            {
                title = title.ToLower();
                podcastsQuery = podcastsQuery.Where(a => a.Title.ToLower().Contains(title));
            }

            return await podcastsQuery
               // .Include(a => a.ArticleCategory)
                .ToListAsync();
        }

    }
}
