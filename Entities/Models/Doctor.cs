using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Doctor
    {
        [Key]
        public string UserId { get; set; }
        public int DoctorCategoryId { get; set; }
        public string? Information { get; set; }
        public DoctorCategories? DoctorCategories { get; set; }
      

    }
}
