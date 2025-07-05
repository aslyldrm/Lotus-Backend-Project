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
    public class DoctorScheduleRepository : RepositoryBase<DoctorSchedule>, IDoctorScheduleRepository
    {
        public DoctorScheduleRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DoctorSchedule>> GetDoctorSchedulesAsync(string doctorId, bool trackChanges)
        {
            return await FindByCondition(ds => ds.DoctorId == doctorId, trackChanges)
                .OrderBy(ds => ds.AvailableFrom)
                .ToListAsync();
        }

        public async Task<IEnumerable<DoctorSchedule>> GetAllDoctorSchedules()
        {
            return await FindAll(false)
                .OrderBy(ds => ds.AvailableFrom)
                .ToListAsync();
        }

        public async Task<DoctorSchedule> GetDoctorScheduleByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(ds => ds.Id == id, trackChanges)
                .FirstOrDefaultAsync();
        }

        public async Task CreateDoctorScheduleAsync(DoctorSchedule schedule)
        {
            Create(schedule);
         
        }

        public async Task UpdateDoctorScheduleAsync(DoctorSchedule schedule)
        {
            Update(schedule);
           
        }

        public async Task DeleteDoctorScheduleAsync(DoctorSchedule schedule)
        {
            Delete(schedule);
      
        }
    }
}
