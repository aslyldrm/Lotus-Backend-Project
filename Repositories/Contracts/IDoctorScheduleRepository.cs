using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IDoctorScheduleRepository : IRepositoryBase<DoctorSchedule>
    {
        Task<IEnumerable<DoctorSchedule>> GetDoctorSchedulesAsync(string doctorId, bool trackChanges);
        Task<DoctorSchedule> GetDoctorScheduleByIdAsync(int id, bool trackChanges);
        Task CreateDoctorScheduleAsync(DoctorSchedule schedule);
        Task UpdateDoctorScheduleAsync(DoctorSchedule schedule);
        Task DeleteDoctorScheduleAsync(DoctorSchedule schedule);
        Task<IEnumerable<DoctorSchedule>> GetAllDoctorSchedules();
    }
}
