using Store.ApplicationService.Contract;
using Store.Core.Products.DataContract;
using Store.Core.Products.Dto.Query;
using Store.Core.Products.Entity;
using Store.Core.Products.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Store.ApplicationService.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _storeUnitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork storeUnitOfWork, IProductRepository productRepository)
        {
            _storeUnitOfWork = storeUnitOfWork;
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
            _storeUnitOfWork.SaveChangesAsync();
        }

        public Product Get(int id)
        {
            return _productRepository.Get(id);
        }

        public async Task<IReadOnlyList<ProductsList>> GetAll()
        {
            return await _productRepository.GetAll();
        }
    }
}
