using Entities.DataTransferObjects.Podcast;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPodcastService
    {

        Task<IEnumerable<Podcast>> GetAllAsync(bool trackChanges);
        Task<Podcast> GetByIdAsync(int id);
        Task<Podcast> AddAsync(IFormFile file, string title, string description, int podcastCategoryId, IFormFile imageFile);
        Task UpdateAsync(int id, string title, string description, string writers, int podcastCategoryId, IFormFile imageFile);
        Task DeleteAsync(int id);
        Task<IEnumerable<Podcast>> GetFilteredPodcastAsync(PodcastFilterParameters podcastParameters, bool trackChanges);
        Task<IEnumerable<Podcast>> SearchPodcastsByTitleAsync(string title, bool trackChanges);


    }
}
