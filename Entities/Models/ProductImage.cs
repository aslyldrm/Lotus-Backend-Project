﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
    }
}
