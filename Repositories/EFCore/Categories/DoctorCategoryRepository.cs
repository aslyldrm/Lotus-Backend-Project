using Entities.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Categories
{
    public class DoctorCategoryRepository : RepositoryBase<DoctorCategories>, IDoctorCategoryRepository
    {
        public DoctorCategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneDoctorCategory(DoctorCategories category)
         => Create(category);

        public void DeleteOneDoctorCategory(DoctorCategories category)
         => Delete(category);   
        public async Task<IEnumerable<DoctorCategories>> GetAllDoctorCategoriesAsync(bool trackChanges)
           => await FindAll(trackChanges)
            .OrderBy(c => c.DoctorCategoryName)
            .ToListAsync();
        public async Task<DoctorCategories> GetOneDoctorCategoryAsync(int id, bool trackChanges)
         => await FindByCondition(c => c.DoctorCategoryId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateOneDoctorCategory(DoctorCategories category)
        => Update(category);    
    }
}
