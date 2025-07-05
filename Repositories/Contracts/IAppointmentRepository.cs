using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IAppointmentRepository :IRepositoryBase<Appointment>
    {
        Task<IEnumerable<Appointment>> GetDoctorAppointmentsAsync(string doctorId, bool trackChanges);
        Task<Appointment> CreateAppointmentAsync(Appointment appointment);
        Task<Appointment> UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(Appointment appointment);
        Task<Appointment> GetAppointmentByIdAsync(int appointmentId, bool trackChanges);
        Task<IEnumerable<Appointment>> GetUserAppointmentsAsync(string userId, bool trackChanges);
        Task<IEnumerable<Appointment>> GetAllDoctorAppointmentsAsync();
    }
}
