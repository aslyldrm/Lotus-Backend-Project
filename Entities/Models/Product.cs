using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        private ProductCategory? productCategory;

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDefinition { get; set; }
        public string? ProductStatus { get; set; }
        //public int UserWhoNeedsId { get; set; }
        public string OwnerId { get; set; }

        public DateTime ProductTime { get; set; } = DateTime.Now;

        public double Price { get; set; }

        public int CategoryId { get; set; }
        public string ProductLocation { get; set; }

        public ProductCategory? ProductCategory { get; set; }
    }
}
