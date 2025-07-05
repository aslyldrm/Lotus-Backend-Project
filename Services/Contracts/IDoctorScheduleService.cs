using Entities.DataTransferObjects.DoctorSchedule;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDoctorScheduleService
    {
        Task<IEnumerable<DoctorScheduleDto>> GetDoctorSchedulesAsync(string doctorId, bool trackChanges);
        Task<DoctorScheduleDto> GetDoctorScheduleByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<DoctorSchedule>> CreateDoctorSchedulesAsync(DoctorScheduleDto scheduleDto);
        Task<DoctorSchedule> UpdateDoctorScheduleAsync(int id, UpdateDoctorScheduling scheduleDto);
        Task<DoctorSchedule> DeleteDoctorScheduleAsync(int id, bool trackChanges);
    }
}
