using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Category.ProductCategory
{
    public record ProductCategoryDtoUpdate : ProductCategoryDtoManipulation
    {
        [Required]
        public int ProductCategoryId { get; init; }
    }
}
