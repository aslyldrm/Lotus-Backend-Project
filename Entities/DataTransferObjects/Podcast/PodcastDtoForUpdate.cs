using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Podcast
{
    public record class PodcastDtoForUpdate : PodcastDtoForManipulation
    {
        public int Id { get; init; }
    }
}
