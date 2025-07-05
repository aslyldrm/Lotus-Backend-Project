using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts.Categories
{
    public interface IDoctorCategoryRepository : IRepositoryBase<DoctorCategories>
    {
        Task<IEnumerable<DoctorCategories>> GetAllDoctorCategoriesAsync(bool trackChanges);

        void CreateOneDoctorCategory(DoctorCategories category);
        void UpdateOneDoctorCategory(DoctorCategories category);
        void DeleteOneDoctorCategory(DoctorCategories category);

        Task<DoctorCategories> GetOneDoctorCategoryAsync(int id, bool trackChanges);
    }
}
