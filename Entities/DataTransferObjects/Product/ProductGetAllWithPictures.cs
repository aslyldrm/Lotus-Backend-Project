using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Product
{
    public record class ProductGetAllWithPictures
    {
        public int Id { get; init; }
        public string ProductName { get; init; }
        public string ProductDefinition { get; init; }
        public string ProductStatus { get; init; }

        public string OwnerId { get; init; }
        public string OwnerName { get; set; }
        public double Price { get; init; }
        public IEnumerable<ProductImage> ProductImages { get; set; }


   

        public DateTime ProductTime { get; set; }

     

        public int CategoryId { get; set; }
        public string ProductLocation { get; set; }

     

    }
}
