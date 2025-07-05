using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Categories
{
    public class DoctorCategories
    {
        [Key]
        public int DoctorCategoryId { get; set; }
        public String? DoctorCategoryName { get; set; }
    }
}
