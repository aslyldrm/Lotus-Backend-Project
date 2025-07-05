using Entities.Models;
using Entities.Models.Categories;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IPodcastRepository : IRepositoryBase<Podcast>
    {

        Task<IEnumerable<Podcast>> GetAllPodcastsAsync(bool trackChanges);
        Task<Podcast> GetPodcastByIdAsync(int id, bool trackChanges);
        Task AddPodcastAsync(Podcast podcast);
        Task UpdatePodcastAsync(Podcast podcast);
        Task DeletePodcastAsync(Podcast podcast);
        Task<IEnumerable<Podcast>> GetFilteredPodcastAsync(PodcastFilterParameters forumParameters, bool trackChanges);
    }
}
