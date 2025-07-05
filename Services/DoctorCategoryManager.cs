using AutoMapper;
using Entities.DataTransferObjects.Categories.DoctorCategory;
using Entities.DataTransferObjects.Category.ArticleCategory;
using Entities.Exceptions.ArticleCategory;
using Entities.Exceptions.Doctor;
using Entities.Models.Categories;
using Repositories.Contracts;
using Services.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DoctorCategoryManager : IDoctorCategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public DoctorCategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<DoctorCategoryDto> CreateOneDoctorCategory(DoctorCategoryDtoForInsertion doctorCategoryDto)
        {
            var entity = _mapper.Map<DoctorCategories>(doctorCategoryDto);
   
            _manager.DoctorCategory.CreateOneDoctorCategory(entity);
             await _manager.SaveAsync();
             return _mapper.Map<DoctorCategoryDto>(entity);
        
        }

        public async Task DeleteOneDoctorCategory(int id, bool trackChanges)
        {
            var entity = await _manager.DoctorCategory.GetOneDoctorCategoryAsync(id, trackChanges);
            if (entity == null)
            {
                throw new DoctorCategoryNotFoundException(id);
            }

            _manager.DoctorCategory.DeleteOneDoctorCategory(entity);
            await _manager.SaveAsync();
        }


        public async Task<DoctorCategories> GetCategoryByIdAsync(int id)
        {
            var entity = await _manager.DoctorCategory.GetOneDoctorCategoryAsync(id, false);
            return entity;
        }
        public async Task<IEnumerable<DoctorCategories>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _manager.DoctorCategory.GetAllDoctorCategoriesAsync(trackChanges);
        }

        public async Task UpdateOneDoctorCategory(DoctorCategoryDtoForUpdate doctorCategoryDto, bool trackChanges)
        {
            var entity = await _manager.DoctorCategory.GetOneDoctorCategoryAsync(doctorCategoryDto.DoctorCategoryId, trackChanges);
            if (entity == null)
            {
                throw new DoctorCategoryNotFoundException(doctorCategoryDto.DoctorCategoryId);


            }
            entity = _mapper.Map<DoctorCategories>(doctorCategoryDto);
            _manager.DoctorCategory.Update(entity);
            await _manager.SaveAsync();
        }
    }
}
