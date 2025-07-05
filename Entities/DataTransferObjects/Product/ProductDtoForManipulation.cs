using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Product
{
    public abstract record ProductDtoForManipulation
    {
        [Required(ErrorMessage = "Product Name is a required field")]
        [MinLength(1, ErrorMessage = "Product Name must consist of at least 1 characters ")]

        public string ProductName { get; init; }


        [Required(ErrorMessage = "Product Definition is a required field")]
        [MinLength(1, ErrorMessage = "Product Definition must consist of at least 1 characters ")]
        public string ProductDefinition { get; init; }


        [Required(ErrorMessage = "Owner Id is a required field")]
     
        public string OwnerId { get; init; }


        [Required(ErrorMessage = "Price is a required field")]
        [Range(0, 10000)]
        public double Price { get; init; }


        [Required(ErrorMessage = "Product Category is a required field")]
        public int CategoryId { get; init; }
        public string ProductLocation { get; init; }
    }
}
