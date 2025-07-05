using Entities.Models;
using Entities.Models.Categories;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class PodcastRepository : RepositoryBase<Podcast>, IPodcastRepository
    {
        public PodcastRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task AddPodcastAsync(Podcast podcast)
        => Create(podcast);

        public async Task DeletePodcastAsync(Podcast podcast)
        => Delete(podcast);

        public async Task<IEnumerable<Podcast>> GetAllPodcastsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<Podcast> GetPodcastByIdAsync(int id, bool trackChanges)
        
           => await FindByCondition(b => b.Id.Equals(id), trackChanges)
           .SingleOrDefaultAsync();
        

        public async Task UpdatePodcastAsync(Podcast podcast)
         =>Update(podcast);

        public async Task<IEnumerable<Podcast>> GetFilteredPodcastAsync(PodcastFilterParameters podcastParameters, bool trackChanges)
        {
            //var articleCategories = await _context.ArticleCategories.ToListAsync();

            // Podcast verilerini çek ve filtreleri uygula
            var podcastQuery = FindAll(trackChanges)
                .AsQueryable();

            ApplyFilters(ref podcastQuery, podcastParameters);


            var podcasts = await podcastQuery.ToListAsync();

            return PagedList<Podcast>.ToPagedList(podcasts, podcastParameters.PageNumber, podcastParameters.PageSize);

        }
        private void ApplyFilters(ref IQueryable<Podcast> podcastQuery, PodcastFilterParameters podcastParameters)
        {
            if (podcastParameters.PodcastCategoryId.HasValue)
           {
                podcastQuery = podcastQuery.Where(a => a.PodcastCategoryId == podcastParameters.PodcastCategoryId.Value);
            }

            if (podcastParameters.SortByAlphabetical)
            {
               podcastQuery = podcastQuery.OrderBy(a => a.Title);
            }
            if (podcastParameters.SortByAlphabeticalDescending)
            {
                podcastQuery = podcastQuery.OrderByDescending(a => a.Title);
            }
            if (podcastParameters.PodcastCategoryId.HasValue)
            {
                podcastQuery = podcastQuery.Where(p => p.PodcastCategoryId == podcastParameters.PodcastCategoryId.Value);
            }
            if (podcastParameters.SortByDate)
            {
                podcastQuery = podcastQuery.OrderByDescending(a => a.ReleaseTime);
            }
            if (podcastParameters.SortByDateAscending)
            {
                podcastQuery = podcastQuery.OrderBy(a => a.ReleaseTime);
            }

        }

    }
}
