using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/filter")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public FilterController(IServiceManager manager)
        {
            _manager = manager;
        }

        //[Authorize]
        [HttpGet("ProductFilterAndGetAllProducts")]
        public async Task<IActionResult> GetAllProductsWithPictures([FromQuery] ProductFilterParameters productParameters)
        {
            var productDtos = await _manager.ProductService.GetAllProductsWithPicturesAsync(productParameters, false);
            return Ok(new { productDtos});
        }
 

        [HttpGet("ArticleFilterAndGetAllArticles")]
        public async Task<IActionResult> GetFilteredArticles([FromQuery] ArticleParameters articleParameters)
        {
            var articles = await _manager.ArticleService.GetFilteredArticlesAsync(articleParameters, trackChanges: false);
            return Ok(articles);
        }

        [HttpGet("ForumFilterAndGetAllForumQuestionsAndAnswers")]
        public async Task<IActionResult> GetFilteredForums([FromQuery] ForumFilterParameters forumParameters)
        {
            var forums = await _manager.ForumService.GetFilteredForumAsync(forumParameters, trackChanges: true);
            return Ok(forums);
        }

        [HttpGet("PodcastFilterAndGetAllPodcasts")]
        public async Task<IActionResult> GetFilteredPodcasts([FromQuery] PodcastFilterParameters podcastParameters)
        {
            var podcasts = await _manager.PodcastService.GetFilteredPodcastAsync(podcastParameters, trackChanges: false);
            return Ok(podcasts);
        }

        [HttpGet("DoctorFilterAndGetAllDoctor")]
        public async Task<IActionResult> GetDoctors([FromQuery] DoctorParameters filterParams)
        {
            var doctors = await _manager.DoctorService.GetFilteredDoctorsAsync(filterParams, trackChanges: false);
            return Ok(doctors);
        }


    }
}
