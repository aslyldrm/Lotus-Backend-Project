using Entities.DataTransferObjects.Appointment;
using Entities.Exceptions.Appointment;
using Entities.Exceptions.Doctor;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Exceptions.NotFoundException;

namespace Presentation.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public AppointmentController(IServiceManager manager)
        {
            _manager = manager;
        }



        [HttpGet("user/{userId}", Name = "GetUserAppointments")]
        public async Task<IActionResult> GetUserAppointments(string userId, [FromQuery] bool trackChanges, [FromQuery] string? month = null)
        {
            DateTime? parsedMonth = null;
            if (!string.IsNullOrEmpty(month))
            {
                if (!DateTime.TryParseExact(month, "MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime tempDate))
                {
                    return BadRequest("Invalid date format. Please use MM-yyyy format.");
                }
                parsedMonth = tempDate;
            }

            var appointments = await _manager.AppointmentService.GetUserAppointmentsDetailsByIdAsync(userId, trackChanges);

            if (parsedMonth.HasValue)
            {
                appointments = appointments.Where(a => a.StartTime.Year == parsedMonth.Value.Year && a.StartTime.Month == parsedMonth.Value.Month).ToList();
            }

            var user = await _manager.AuthenticationService.FindByIdAsync(userId,false);
            if (user == null)
            {
                return NotFound($"User with id {userId} not found");
            }

            var appointmentDtos = new List<AppointmentDetailsDto>();

            foreach (var appointment in appointments)
            {
                var doctor = await _manager.DoctorService.GetDoctorByUserIdAsync(appointment.DoctorId, false);
                var doctorCategories = await _manager.DoctorCategoryService.GetCategoryByIdAsync(doctor.DoctorCategoryId);
                if (doctor == null)
                {
                    return NotFound($"Doctor with ID {appointment.DoctorId} not found");
                }

                var appointmentDto = new AppointmentDetailsDto
                {
                    AppointmentId = appointment.Id,
                    StartTime = appointment.StartTime,
                    EndTime = appointment.EndTime,
                    Status = appointment.Status,
                    DoctorName = $"{doctor.UserName} {doctor.Surname}",
                    DoctorCategoryId = doctor.DoctorCategoryId,
                    DoctorCategoryName = doctorCategories.DoctorCategoryName
                };

                appointmentDtos.Add(appointmentDto);
            }

            var userAppointmentsDto = new UserAppointmentsDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Surname = user.Surname,
                Email = user.Email,
                Appointments = appointmentDtos
            };

            return Ok(userAppointmentsDto);
        }

 

        [HttpGet("doctor/{doctorId}/availability")]
        public async Task<IActionResult> GetAvailableSlots(string doctorId, [FromQuery] string month)
        {
            if (!DateTime.TryParseExact(month, "MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedMonth))
            {
                return BadRequest("Invalid date format. Please use MM-yyyy format.");
            }

            var slots = await _manager.AppointmentService.GetAvailableSlotsAsync(doctorId, parsedMonth);
            return Ok(slots);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDto appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest("AppointmentDto object is null");
            }

            try
            {
                 await _manager.AppointmentService.CreateAppointmentAsync(appointmentDto);
                return Ok();
            }
            catch (AppointmentConflictException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{appointmentId}/cancelAppointment")]
        public async Task<IActionResult> DeleteAppointment(int appointmentId)
        {
            try
            {
                await _manager.AppointmentService.DeleteAppointmentAsync(appointmentId);
                return NoContent();
            }
            catch (AppointmentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("futureAppointments/{userId}")]
        public async Task<IActionResult> GetUserAvailableAppointments(string userId)
        {
           

            var appointments = await _manager.AppointmentService.GetUserAppointmentsDetailsByIdAsync(userId, false);

            // Geçmiş randevuları filtrele
            appointments = appointments.Where(a => a.EndTime >= DateTime.Now).ToList();

           

            var user = await _manager.AuthenticationService.FindByIdAsync(userId, false);
            if (user == null)
            {
                return NotFound($"User with id {userId} not found");
            }

            var appointmentDtos = new List<AppointmentDetailsDto>();

            foreach (var appointment in appointments)
            {
                var doctor = await _manager.DoctorService.GetDoctorByUserIdAsync(appointment.DoctorId, false);
                if (doctor == null)
                {
                    return NotFound($"Doctor with ID {appointment.DoctorId} not found");
                }
                var doctorCategories = await _manager.DoctorCategoryService.GetCategoryByIdAsync(doctor.DoctorCategoryId);
                var appointmentDto = new AppointmentDetailsDto
                {
                    AppointmentId = appointment.Id,
                    StartTime = appointment.StartTime,
                    EndTime = appointment.EndTime,
                    Status = appointment.Status,
                    DoctorName = $"{doctor.UserName} {doctor.Surname}",
                    DoctorCategoryId = doctor.DoctorCategoryId,
                    DoctorCategoryName = doctorCategories.DoctorCategoryName
                };

                appointmentDtos.Add(appointmentDto);
            }

            var userAppointmentsDto = new UserAppointmentsDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Surname = user.Surname,
                Email = user.Email,
                Appointments = appointmentDtos
            };

            return Ok(userAppointmentsDto);
        }


        [HttpGet("doctor/{doctorId}/future-availability")]
        public async Task<IActionResult> GetFutureAvailableSlots(string doctorId, [FromQuery] string month)
        {
            if (!DateTime.TryParseExact(month, "MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedMonth))
            {
                return BadRequest("Invalid date format. Please use MM-yyyy format.");
            }

            var slots = await _manager.AppointmentService.GetFutureAvailableSlotsAsync(doctorId, parsedMonth);
            return Ok(slots);
        }


    }
}
