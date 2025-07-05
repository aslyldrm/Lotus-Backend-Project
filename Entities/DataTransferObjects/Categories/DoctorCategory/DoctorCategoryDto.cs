using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Categories.DoctorCategory
{
    public record class DoctorCategoryDto
    {

        public int DoctorCategoryId { get; init; }
        public String? DoctorCategoryName { get; init; }
    }

    public record class DoctorCategoryDtoForInsertion  : DoctorCategoryDtoForManipulation
    {
    }
    public record class DoctorCategoryDtoForManipulation
    {

        [Required]
        public String DoctorCategoryName { get; init; }
    }

    public record class DoctorCategoryDtoForUpdate : DoctorCategoryDtoForManipulation
    {
        public int DoctorCategoryId { get; init; }
        
    }
}
