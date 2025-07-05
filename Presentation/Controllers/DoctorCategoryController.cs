using Entities.DataTransferObjects.Categories.DoctorCategory;
using Entities.DataTransferObjects.Category.ArticleCategory;
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
    [Route("api/doctorCategories")]
    public class DoctorCategoryController : ControllerBase
    {
        private readonly IServiceManager _services;

        public DoctorCategoryController(IServiceManager services)
        {
            _services = services;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllDoctorCategories()
        {
            return Ok(await _services.DoctorCategoryService
                .GetAllCategoriesAsync(false));
        }


        [HttpPost]
        public async Task<IActionResult> CreateOneDoctorCategoryAsync(
            [FromBody] DoctorCategoryDtoForInsertion doctorCategoryDtoInsertion)
        {
            var articleCategory = await _services.DoctorCategoryService
                .CreateOneDoctorCategory(doctorCategoryDtoInsertion);
            return Ok(articleCategory);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOneDoctorCategoryAsync(
            [FromBody] DoctorCategoryDtoForUpdate doctorCategoryDto)
        {
            if (doctorCategoryDto == null)
                return NotFound();
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

       

            await _services.DoctorCategoryService.UpdateOneDoctorCategory( doctorCategoryDto, false);

            return Ok(doctorCategoryDto); //204
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneDoctorCategoryAsync([FromRoute(Name = "id")] int id)
        {


            await _services.DoctorCategoryService.DeleteOneDoctorCategory(id, false);

            return NoContent();
        }
    }
}
