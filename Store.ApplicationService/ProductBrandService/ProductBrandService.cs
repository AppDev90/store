using Store.ApplicationService.Common;
using Store.ApplicationService.Contract;
using Store.ApplicationService.Factory;
using Store.Core.ProductBrands.DataContract;
using Store.Core.ProductBrands.Entity;
using Store.Core.ProductBrands.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ApplicationService.ProductBrandService
{
    public class ProductBrandService : BaseService, IProductBrandService
    {
        private readonly IUnitOfWork _storeUnitOfWork;
        private readonly IProductBrandRepository _productBandRepository;

        public ProductBrandService(IUnitOfWork storeUnitOfWork, IProductBrandRepository productBandRepository, ErrorFactory errorFactory)
            : base(errorFactory)
        {
            _storeUnitOfWork = storeUnitOfWork;
            _productBandRepository = productBandRepository;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAll()
        {
            return await _productBandRepository.GetAll();
        }
    }
}
