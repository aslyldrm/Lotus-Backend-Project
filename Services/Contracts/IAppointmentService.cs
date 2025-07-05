using Entities.DataTransferObjects.Appointment;
using Entities.DataTransferObjects.DoctorSchedule;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetDoctorAppointmentsAsync(string doctorId, bool trackChanges, DateTime? month = null);
        Task<IEnumerable<TimeSlotDto>> GetAvailableSlotsAsync(string doctorId, DateTime date);
        Task<AppointmentDto> CreateAppointmentAsync(AppointmentDto appointmentDto);
        Task DeleteAppointmentAsync(int appointmentId);
        Task<IEnumerable<AppointmentDto>> GetUserAppointmentsAsync(string userId, bool trackChanges);
        Task<IEnumerable<Appointment>> GetUserAppointmentsDetailsByIdAsync(string userId, bool trackChanges);
        Task<IEnumerable<TimeSlotDtoGetAll>> GetAllDoctorsAvailableSlotsAsync(DateTime month, int? categoryId = null);
        Task<IEnumerable<TimeSlotDtoGetAll>> SearchDoctorSchedulesAsync(string query);
        Task<IEnumerable<Appointment>> GetDoctorAppointmentsAsync(string doctorId, bool trackChanges);
        Task<IEnumerable<TimeSlotDto>> GetFutureAvailableSlotsAsync(string doctorId, DateTime month);






    }
}
