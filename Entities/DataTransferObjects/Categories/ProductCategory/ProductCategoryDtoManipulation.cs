using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Category.ProductCategory
{
    public abstract record ProductCategoryDtoManipulation
    {
        [Required(ErrorMessage = "Category Name is a required field")]
        public string productCategoryName { get; init; }

    }
}
