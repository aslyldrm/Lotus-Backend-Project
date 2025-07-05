using Entities.DataTransferObjects.Podcast;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/podcast")]

    public class PodcastsController  : ControllerBase
    {
        private readonly IServiceManager _services;

        public PodcastsController(IServiceManager services)
        {
            _services = services;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Podcast>>> GetPodcasts()
        {
            var podcasts = await _services.PodcastService.GetAllAsync(false);
            return Ok(podcasts);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Podcast>> GetPodcast(int id)
        {
            var podcast = await _services.PodcastService.GetByIdAsync(id);
            if (podcast == null)
            {
                return NotFound();
            }
            return Ok(podcast);
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<Podcast>> PostPodcast( IFormFile file, [FromForm] string title, [FromForm] int podcastCategory, [FromForm] string description, IFormFile ImageFile)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var podcast = await _services.PodcastService.AddAsync(file, title, description, podcastCategory, ImageFile);
        
            
            return Ok(podcast);
            
  
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePodcast(int id, [FromForm] string title, [FromForm] string description, [FromForm] int podcastCategory, [FromForm] string writers, IFormFile image)
        {
            await _services.PodcastService.UpdateAsync(id, title, description,writers, podcastCategory, image);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePodcast(int id)
        {
            await _services.PodcastService.DeleteAsync(id);
            return NoContent();
        }












    }
}
