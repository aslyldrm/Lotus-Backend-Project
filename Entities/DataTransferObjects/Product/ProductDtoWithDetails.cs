using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Product
{
    public record class ProductDtoWithDetails : ProductDto
    {
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public string OwnerName { get; set; }
        public string ProductLocation { get; init; }
    }
}
