using Entities.DataTransferObjects.Doctor;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public DoctorsController(IServiceManager manager)
        {
            _manager = manager;
        }


        [HttpGet("{userId}", Name = "DoctorByUserId")]
        public async Task<IActionResult> GetDoctorByUserId(string userId)
        {
            var doctor = await _manager.DoctorService.GetDoctorByUserIdAsync(userId, false);
            return Ok(doctor);
        }


        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorDtoForInsertion doctorForCreation)
        {
            if (doctorForCreation == null)
            {
                return BadRequest("Doctor object is null");
            }

              await _manager.DoctorService.CreateOneDoctorAsync(doctorForCreation);
            return Ok();
        }



        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateDoctor(string userId, [FromForm] DoctorDtoForUpdate doctorUpdateDto)
        {
            if (doctorUpdateDto == null)
            {
                return BadRequest("DoctorUpdateDto object is null");
            }

            await _manager.DoctorService.UpdateDoctorAsync(userId, doctorUpdateDto, true);
            return NoContent();
        }


        [HttpDelete("{userId}")]

        public async Task<IActionResult> DeleteDoctor(string userId)
        {
            await _manager.DoctorService.DeleteDoctorAsync(userId, false);
            return NoContent();
        }
    }
}
