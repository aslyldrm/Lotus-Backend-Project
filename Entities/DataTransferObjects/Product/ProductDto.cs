using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Product
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string ProductName { get; init; }
        public string ProductDefinition { get; init; }
        public string ProductStatus { get; init; }
 
        public string OwnerId { get; init; }
        public double Price { get; init; }

    }
}
