using Entities.DataTransferObjects.Doctor;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetFilteredDoctorsAsync(DoctorParameters filterParams, bool trackChanges);
        Task<DoctorDto> GetDoctorByUserIdAsync(string userId, bool trackChanges);
        Task UpdateDoctorAsync(string userId, DoctorDtoForUpdate doctorUpdateDto, bool trackChanges);
        Task DeleteDoctorAsync(string userId, bool trackChanges);
        Task<DoctorDto> CreateOneDoctorAsync(DoctorDtoForInsertion doctor);
        Task<IEnumerable<DoctorDto>> SearchDoctorsAsync(string searchTerm, bool trackChanges);


    }
}
