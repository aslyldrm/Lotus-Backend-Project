using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Appointment>> GetDoctorAppointmentsAsync(string doctorId, bool trackChanges)
        {
            return await FindByCondition(a => a.DoctorId == doctorId, trackChanges)
          .OrderBy(a => a.StartTime)
          .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAllDoctorAppointmentsAsync()
        {
            return await FindAll(false)
          .OrderBy(a => a.StartTime)
          .ToListAsync();
        }
        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            Create(appointment);
        
            return appointment;
        }

        public async Task<Appointment> UpdateAppointmentAsync(Appointment appointment)
        {
            Update(appointment);
            
            return appointment;
        }

        public async Task DeleteAppointmentAsync(Appointment appointment)
        {
            Delete(appointment);
  
        }
        public async Task<Appointment> GetAppointmentByIdAsync(int appointmentId, bool trackChanges)
        {
            return await FindByCondition(a => a.Id.Equals(appointmentId), trackChanges)
                          .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Appointment>> GetUserAppointmentsAsync(string userId, bool trackChanges)
        {
            var appointments = await FindByCondition(a => a.UserId == userId, trackChanges)
        .OrderBy(a => a.StartTime)
        .ToListAsync();


            return appointments;
        }

    }
}
