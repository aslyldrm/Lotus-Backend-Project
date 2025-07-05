using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Podcast
{
    public record class PodcastDtoInsertionForFilePart
    {
        [Required]
        public IFormFile File { get; init; }
        [Required]
        public string Title { get; init; }
        public string? Description { get; init; }
        public string? ReleaseDate { get; init; }
        public string? Writers { get; init; }
        public string? Image { get; init; }
    }
}
