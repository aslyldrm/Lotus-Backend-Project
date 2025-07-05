using Entities.DataTransferObjects.Doctor;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneDoctor(Doctor doctor)
         => Create(doctor);

        public void DeleteOneDoctor(Doctor doctor)
        => Delete(doctor);

        public async Task<IEnumerable<Doctor>> GetFilteredDoctorsAsync(DoctorParameters filterParams, bool trackChanges)
        {
            return FindAll(trackChanges)
                   .Include(x => x.DoctorCategories)
                   .AsQueryable(); 
        }

        public async Task<Doctor> GetOneDoctorByUserIdAsync(string userId, bool trackChanges)
        {
            IQueryable<Doctor> query = _context.Doctors
                .Include(d => d.DoctorCategories)
                .Where(d => d.UserId == userId );

            //return await query.SingleOrDefaultAsync();
            return await (trackChanges ? query : query.AsNoTracking()).SingleOrDefaultAsync();
        }

        public void UpdateOneDoctor(Doctor doctor)
        => Update(doctor);

        public async Task<IEnumerable<DoctorDto>> SearchDoctorsAsync(string searchTerm, bool trackChanges)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return Enumerable.Empty<DoctorDto>();
            }

            var query = from doctor in _context.Doctors
                        join user in _context.Users on doctor.UserId equals user.Id
                        where doctor.Information.Contains(searchTerm) ||
                              user.Surname.Contains(searchTerm) ||
                              user.UserName.Contains(searchTerm)
                        select new DoctorDto
                        {
                            UserId = doctor.UserId,
                            UserName = user.UserName,
                            Surname = user.Surname,
                            Email = user.Email,
                            DoctorCategoryId = doctor.DoctorCategoryId,
                            Information = doctor.Information,
                            Image = user.Image
                        };

            return await (trackChanges ? query : query.AsNoTracking()).ToListAsync();
        }

      
    }
}
