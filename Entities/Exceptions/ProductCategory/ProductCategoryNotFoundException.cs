using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.ProductCategory
{
    public class ProductCategoryNotFoundException : NotFoundException
    {
        public ProductCategoryNotFoundException(int id) : base($"The Product category with id : {id} not found")
        {
        }
    }
}
