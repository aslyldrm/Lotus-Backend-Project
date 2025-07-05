using AutoMapper;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Entities.DataTransferObjects.Article;
using Entities.DataTransferObjects.User;
using Entities.Exceptions.Article;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Exceptions.NotFoundException;
using static System.Net.Mime.MediaTypeNames;

namespace Services
{
    public class ArticleManager : IArticleService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
       

        public ArticleManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
      
        }

        public async Task<ArticleDto> CreateOneArticleAsync(ArticleDtoForInsertion articleDto)
        {


            string imgUrl = null;

            if (articleDto.Image != null && articleDto.Image.Length > 0)
            {
                imgUrl = await UploadImageToBlobAsync(articleDto.Image);
            }

            var entity = _mapper.Map<Article>(articleDto);
            entity.Image = imgUrl;
           
            _manager.Article.CreateOneArticle(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ArticleDto>(entity);
        }

        public async Task DeleteOneArticleAsync(int id, bool trackChanges)
        {


            //checking entity
            var entity = await _manager.Article.GetOneArticleByIdAsync(id, trackChanges);
            if (entity == null)
            {
                throw new ArticleNotFoundExceptions(id);
            }

            _manager.Article.DeleteOneArticle(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<Article> articles, MetaData metaData)> GetAllArticlesAsync( ArticleParameters articleParameters, bool trackChanges)
        {
            var articlesWithMetaData = await _manager.Article.GetAllArticlesAsync(articleParameters, trackChanges);
          
            var articlesDto = _mapper.Map<IEnumerable<Article>>(articlesWithMetaData);
            
            return (articlesDto, articlesWithMetaData.MetaData);
        }

        public async Task<ArticleDto> GetOneArticleByIdAsync(int id, bool trackChanges)
        {
            var article = await _manager.Article.GetOneArticleByIdAsync(id, trackChanges);


            if (article == null)
                throw new ArticleNotFoundExceptions(id);

            return _mapper.Map<ArticleDto>(article);
        }

        public async Task UpdateOneArticleAsync(int id, ArticleDtoForUpdate articleDto, bool trackChanges)
        {
       
            var entity = await _manager.Article.GetOneArticleByIdAsync(id, trackChanges);
            if (entity == null)
            {

                throw new ArticleNotFoundExceptions(id);
            }
            if (articleDto.Title != "string" && !string.IsNullOrEmpty(articleDto.Title))
            {
                entity.Title = articleDto.Title;
            }

            if (!string.IsNullOrEmpty(articleDto.ContentText) && articleDto.ContentText != "string")
            {
                entity.ContentText = articleDto.ContentText;
            }

            if (!string.IsNullOrEmpty(articleDto.Writers) && articleDto.Writers != "stringstri")
            {
                entity.Writers = articleDto.Writers;
            }

            if (articleDto.ArticleCategoryId != default && articleDto.ArticleCategoryId != 0)
            {
                entity.ArticleCategoryId = (int)articleDto.ArticleCategoryId;
            }
            if (articleDto.Image != null && articleDto.Image.Length > 0)
            {
                entity.Image = await UploadImageToBlobAsync(articleDto.Image);
            }




            entity = _mapper.Map<Article>(entity);
            _manager.Article.Update(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ArticleDto>> GetFilteredArticlesAsync(ArticleParameters articleParameters, bool trackChanges)
        {
            var articles = await _manager.Article.GetFilteredArticlesAsync(articleParameters, trackChanges);
            
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }

        public async Task<IEnumerable<Article>> SearchArticlesByTitleAsync(string title, bool trackChanges)
        {
            var articlesQuery = _manager.Article.FindAll(trackChanges);

            if (!string.IsNullOrWhiteSpace(title))
            {
                title = title.ToLower();
                articlesQuery = articlesQuery.Where(a => a.Title.ToLower().Contains(title));
            }

            return await articlesQuery
                .Include(a => a.ArticleCategory)
                .ToListAsync();
        }
        private async Task<string> UploadImageToBlobAsync(IFormFile image)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=lotusarticlepicture;AccountKey=1OozC4m14OR4WRlselOc73lHEelQ9Ldmu+iNLErLKgiCdFbueubno6CgocfMFXI52ED8KRIUjQlH+ASt5yJlPw==;EndpointSuffix=core.windows.net";
            string containerName = "lotusarticlepicture";

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

            // SAS token oluşturma
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            DateTimeOffset utcExpiry = utcNow.AddYears(1); // SAS URL'nin geçerlilik süresi

            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerClient.Name,
                BlobName = blobClient.Name,
                Resource = "b",
                StartsOn = utcNow,
                ExpiresOn = utcExpiry
            };

            sasBuilder.SetPermissions(BlobSasPermissions.Read);

            string sasToken = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(blobServiceClient.AccountName, "1OozC4m14OR4WRlselOc73lHEelQ9Ldmu+iNLErLKgiCdFbueubno6CgocfMFXI52ED8KRIUjQlH+ASt5yJlPw==")).ToString();
            UriBuilder sasUri = new UriBuilder(blobClient.Uri)
            {
                Query = sasToken
            };

            return sasUri.ToString();
        }



        
    }
}
