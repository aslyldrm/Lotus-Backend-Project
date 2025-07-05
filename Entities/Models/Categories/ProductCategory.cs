using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Categories
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public String? ProductCategoryName { get; set; }
   
    }
}
