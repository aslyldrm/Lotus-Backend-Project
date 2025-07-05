using Entities.DataTransferObjects.Doctor;
using Entities.Models;
using Entities.Models.Categories;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IDoctorRepository : IRepositoryBase<Doctor>
    {
        Task<Doctor> GetOneDoctorByUserIdAsync(string userId, bool trackChanges);
        void CreateOneDoctor(Doctor doctor);
        void UpdateOneDoctor(Doctor doctor);
        void DeleteOneDoctor(Doctor doctor);
        Task<IEnumerable<Doctor>> GetFilteredDoctorsAsync(DoctorParameters filterParams, bool trackChanges);
        Task<IEnumerable<DoctorDto>> SearchDoctorsAsync(string searchTerm, bool trackChanges);
     
    }
}
