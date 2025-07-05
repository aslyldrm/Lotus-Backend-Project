using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Azure.Storage;
using Entities.DataTransferObjects.Doctor;
using Entities.DataTransferObjects.Forum;
using Entities.DataTransferObjects.User;
using Entities.Exceptions;
using Entities.Exceptions.Doctor;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Exceptions.NotFoundException;

namespace Services
{
    public class DoctorManager : IDoctorService 
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<User> _userManager;

        public DoctorManager(IRepositoryManager manager, IMapper mapper, IServiceManager serviceManager, UserManager<User> userManager)
        {
            _manager = manager;
            _mapper = mapper;
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        public async Task<DoctorDto> CreateOneDoctorAsync(DoctorDtoForInsertion doctor)
        {


            var entity = _mapper.Map<Doctor>(doctor);

        
       
              
             _manager.Doctor.CreateOneDoctor(entity); 
            await _manager.SaveAsync();
            return  _mapper.Map<DoctorDto>(entity);
            


        }

        public async Task DeleteDoctorAsync(string userId, bool trackChanges)
        {
            var doctor = await _manager.Doctor.GetOneDoctorByUserIdAsync(userId, trackChanges);
            if (doctor == null)
            {
                throw new DoctorNotFoundException($"Doctor with userId {userId} not found");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException($"User with id {userId} not found");
            }

            await _userManager.DeleteAsync(user);
            _manager.Doctor.DeleteOneDoctor(doctor);
        }

        public async Task<IEnumerable<DoctorDto>> GetFilteredDoctorsAsync(DoctorParameters filterParams, bool trackChanges)
        {
            var doctors = await _manager.Doctor.GetFilteredDoctorsAsync(filterParams, trackChanges);
            var doctorsQuery = doctors.AsQueryable();

            // Doktorların UserId'lerini kullanarak UserManager'dan bilgileri çekiyoruz
            var userIds = doctors.Select(d => d.UserId).ToList();

            // Kullanıcı bilgilerini UserManager'dan alıyoruz
            var users = new List<User>();
            foreach (var userId in userIds)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    users.Add(user);
                }
            }

            var result = from doctor in doctors
                         join user in users on doctor.UserId equals user.Id
                         select new DoctorDto
                         {
                             UserId = user.Id,
                             UserName = user.UserName,
                             Surname = user.Surname,
                             Email = user.Email,
                             DoctorCategoryId = doctor.DoctorCategoryId,
                             Information = doctor.Information,
                             Image = user.Image

                             // Diğer gerekli bilgiler
                         };

            // Filtreleme ve sıralama işlemleri
            if (filterParams.DoctorCategoryId.HasValue)
            {
                result = result.Where(d => d.DoctorCategoryId == filterParams.DoctorCategoryId.Value);
            }

            if (filterParams.SortByAlphabetical)
            {
                result = result.OrderBy(d => d.UserName); // Kullanıcı adına göre sıralama
            }

            if (filterParams.SortByAlphabeticalDescending)
            {
                result = result.OrderByDescending(d => d.UserName); // Kullanıcı adına göre ters sıralama
            }

            var pagedResult = result
        .Skip((filterParams.PageNumber - 1) * filterParams.PageSize)
        .Take(filterParams.PageSize);

            return pagedResult.ToList();
        }

        public async Task<DoctorDto> GetDoctorByUserIdAsync(string userId, bool trackChanges)
        {
            var doctor = await _manager.Doctor.GetOneDoctorByUserIdAsync(userId, trackChanges);
            if (doctor == null)
            {
                throw new DoctorNotFoundException($"Doctor with userId {userId} not found");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException($"User with id {userId} not found");
            }

            var doctorDto = new DoctorDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Surname = user.Surname,
                Email = user.Email,
                DoctorCategoryId = doctor.DoctorCategoryId,
                Information = doctor.Information,
                Image = user.Image
                // Diğer gerekli bilgiler
            };

            return doctorDto;
        }

        public async Task UpdateDoctorAsync(string userId, DoctorDtoForUpdate doctorUpdateDto, bool trackChanges)
        {
            var doctor = await _manager.Doctor.GetOneDoctorByUserIdAsync(userId, trackChanges);
            if (doctor == null)
            {
                throw new DoctorNotFoundException($"Doctor with userId {userId} not found");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException($"User with id {userId} not found");
            }

            _mapper.Map(doctorUpdateDto, doctor);

            if (doctorUpdateDto.Information != "string" && !string.IsNullOrEmpty(doctorUpdateDto.Information))
            {
                doctor.Information = doctorUpdateDto.Information;
                _manager.Doctor.UpdateOneDoctor(doctor);


            }
            if (doctorUpdateDto.DoctorCategoryId != 0)
            {
                doctor.DoctorCategoryId = doctorUpdateDto.DoctorCategoryId;
                _manager.Doctor.UpdateOneDoctor(doctor);


            }
     

          
         
            await _manager.SaveAsync();

        }


        private async Task<string> UploadImageToBlobAsync(IFormFile image)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=lotususerpictures;AccountKey=jw2c3I6FsBnttRSjJB00UbS/XuK368UiUTpfHVul4xCPROXR1Bfm9D6M32GFdyirA8Wok1icphQr+ASt/X6dBw==;EndpointSuffix=core.windows.net";
            string containerName = "lotususerpictures";

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            await containerClient.CreateIfNotExistsAsync();

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            using (var ms = new MemoryStream())
            {
                await image.CopyToAsync(ms);
                ms.Position = 0;
                await blobClient.UploadAsync(ms, true);
            }

            // SAS token oluşturma
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            DateTimeOffset utcExpiry = utcNow.AddYears(1); // SAS URL'nin geçerlilik süresi


            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerClient.Name,
                BlobName = blobClient.Name,
                Resource = "b",
                StartsOn = utcNow,
                ExpiresOn = utcExpiry
            };

            sasBuilder.SetPermissions(BlobSasPermissions.Read);

            string sasToken = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(blobServiceClient.AccountName, "jw2c3I6FsBnttRSjJB00UbS/XuK368UiUTpfHVul4xCPROXR1Bfm9D6M32GFdyirA8Wok1icphQr+ASt/X6dBw==")).ToString();
            UriBuilder sasUri = new UriBuilder(blobClient.Uri)
            {
                Query = sasToken
            };

            return sasUri.ToString();
        }

        public async Task<IEnumerable<DoctorDto>> SearchDoctorsAsync(string searchTerm, bool trackChanges)
        {
            var doctors = await _manager.Doctor.SearchDoctorsAsync(searchTerm, trackChanges);
            return doctors;
        }

    }
}
