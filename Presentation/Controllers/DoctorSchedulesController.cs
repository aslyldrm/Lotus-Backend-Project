using Entities.DataTransferObjects.DoctorSchedule;
using Entities.Exceptions.DoctorSchedule;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/doctorSchedules")]
    [ApiController]
    public class DoctorSchedulesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public DoctorSchedulesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetDoctorSchedules(string doctorId)
        {
            var schedules = await _manager.AppointmentScheduleService.GetDoctorSchedulesAsync(doctorId, false);
            return Ok(schedules);
        }



        [HttpGet("GetAllDoctorSchedules")]
        public async Task<IActionResult> GetAllDoctorSchedules([FromQuery] string month, [FromQuery] int? categoryId)
        {
            if (!DateTime.TryParseExact(month, "MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedMonth))
            {
                return BadRequest("Invalid date format. Please use MM-yyyy format.");
            }
            var schedules = await _manager.AppointmentService.GetAllDoctorsAvailableSlotsAsync(parsedMonth, categoryId);
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAppointmenstWithDetails(int id)
        {
            var schedule = await _manager.AppointmentScheduleService.GetDoctorScheduleByIdAsync(id, false);
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctorSchedule([FromBody] DoctorScheduleDto scheduleDto)
        {
            if (scheduleDto == null)
            {
                return BadRequest("DoctorScheduleDto object is null");
            }

            try
            {
                await _manager.AppointmentScheduleService.CreateDoctorSchedulesAsync(scheduleDto);
                return Ok();
            }
            catch (InvalidScheduleTimeException ex)
            {
                return BadRequest(ex.Message);
            }
        }


       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctorSchedule(int id, [FromBody] UpdateDoctorScheduling scheduleDto)
        {
            if (scheduleDto == null)
            {
                return BadRequest("UpdateDoctorScheduling object is null");
            }

            try
            {
               await _manager.AppointmentScheduleService.UpdateDoctorScheduleAsync(id, scheduleDto);
                return Ok();
            }
            catch (ScheduleNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ScheduleConflictException ex)
            {
                return Conflict(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorSchedule(int id)
        {
            await _manager.AppointmentScheduleService.DeleteDoctorScheduleAsync(id, false);
            return NoContent();
        }
    }
}
