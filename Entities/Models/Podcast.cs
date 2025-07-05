using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Podcast
    {

   


        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Url { get; set; }

        public string? Writers { get; set; }
        public string? Image { get; set; }

        public int PodcastCategoryId { get; set; }
        public DateTime ReleaseTime { get; set; } = DateTime.Now;
        // public ArticleCategory? PodcastCategory { get; set; }


    }
}
