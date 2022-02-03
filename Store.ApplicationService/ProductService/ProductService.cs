using Store.ApplicationService.Common;
using Store.ApplicationService.Contract;
using Store.ApplicationService.Factory;
using Store.Core.Common.Dto;
using Store.Core.Products.DataContract;
using Store.Core.Products.Dto;
using Store.Core.Products.Dto.Query;
using Store.Core.Products.Entity;
using Store.Core.Products.ServiceContract;

using System.Threading.Tasks;

namespace Store.ApplicationService.ProductService
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IUnitOfWork _storeUnitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork storeUnitOfWork, IProductRepository productRepository, ErrorFactory errorFactory)
            : base(errorFactory)
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

        public async Task<Pagination<ProductsWithDetail>> GetPdoducts(FilterDto filterDto)
        {
            var products = await _productRepository.GetProducts(filterDto);
            var productCount = await _productRepository.GetCount(filterDto);

            return new Pagination<ProductsWithDetail>(filterDto.PageIndex, filterDto.PageSize,
                productCount, products);
        }

        public async Task<ProductsWithDetail> GetWithDetail(int id)
        {
            var product = await _productRepository.GetWithDetail(id);
            if (product == null)
                NotFoundError.Throw("Product");
            return product;
        }
    }
}
