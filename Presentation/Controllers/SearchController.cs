using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SearchController(IServiceManager manager)
        {
            _service = manager;
        }

        [HttpGet("ProductSearch")]
        public async Task<IActionResult> SearchProductsByName([FromQuery] string productName)
        {
            var products = await _service.ProductService.SearchProductsByNameAsync(productName, trackChanges: false);
            return Ok(products);
        }
        [HttpGet("ArticleSearch")]
        public async Task<IActionResult> SearchArticlesByTitle([FromQuery] string title)
        {
            var articles = await _service.ArticleService.SearchArticlesByTitleAsync(title, trackChanges: false);
            return Ok(articles);
        }

        [HttpGet("ForumSearch")]
        public async Task<IActionResult> SearchForumQuestionsByQuestionTitle([FromQuery] string questiontitle)
        {
            var questions = await _service.ForumService.SearchForumQuestionsByQuestionTitleAsync(questiontitle, trackChanges: false);
            return Ok(questions);
        }
        [HttpGet("PodcastSearch")]
        public async Task<IActionResult> SearchPodcastsByPodcastTitle([FromQuery] string title)
        {
            var podcasts = await _service.PodcastService.SearchPodcastsByTitleAsync(title, trackChanges: false);
            return Ok(podcasts);
        }

        [HttpGet("DoctorSearch")]
        public async Task<IActionResult> SearchDoctors([FromQuery] string searchTerm)
        {
            var doctors = await _service.DoctorService.SearchDoctorsAsync(searchTerm, trackChanges: false);
            return Ok(doctors);
        }

        [HttpGet("SearchDoctorSchedules")]
        public async Task<IActionResult> SearchDoctorSchedules([FromQuery] string query)
        {
            var schedules = await _service.AppointmentService.SearchDoctorSchedulesAsync(query);
            return Ok(schedules);
        }

    }
}
