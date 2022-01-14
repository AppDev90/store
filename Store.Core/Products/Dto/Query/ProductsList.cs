﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Products.Dto.Query
{
    public class ProductsList
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}
