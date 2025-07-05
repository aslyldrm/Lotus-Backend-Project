using Entities.DataTransferObjects.Categories.DoctorCategory;
using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts.Categories
{
    public interface IDoctorCategoryService
    {
        Task<IEnumerable<DoctorCategories>> GetAllCategoriesAsync(bool trackChanges);
        Task<DoctorCategoryDto> CreateOneDoctorCategory(DoctorCategoryDtoForInsertion doctorCategoryDto);
        Task UpdateOneDoctorCategory( DoctorCategoryDtoForUpdate doctorCategoryDto, bool trackChanges);
        Task DeleteOneDoctorCategory(int id, bool trackChanges);
        Task<DoctorCategories> GetCategoryByIdAsync(int id);
    }
}
