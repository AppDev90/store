﻿using Store.Core.Products.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.Products.DataContract
{
    public interface IProductRepository
    {
        Product Get(int id);
        Task<IReadOnlyList<Product>> GetAll();
        void Add(Product product);
    }
}