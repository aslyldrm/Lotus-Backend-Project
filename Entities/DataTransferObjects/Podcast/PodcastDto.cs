using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Podcast
{
    public record class PodcastDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string? Description { get; init; }
        public string Url { get; init; }
        public int PodcastCategoryId { get; init; }


        public string? Writers { get; init; }
        public string? Image { get; init; }

    }
}
