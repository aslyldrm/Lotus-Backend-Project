using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Category.ProductCategory
{
    public record ProductCategoryDto
    {
        public int CategoryId { get; init; }
        public string CategoryName { get; init; }
    }
}
