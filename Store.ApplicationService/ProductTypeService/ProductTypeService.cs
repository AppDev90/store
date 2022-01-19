

using Store.ApplicationService.Common;
using Store.ApplicationService.Contract;
using Store.ApplicationService.Factory;
using Store.Core.ProductTypes.DataContract;
using Store.Core.ProductTypes.Entity;
using Store.Core.ProductTypes.ServiceContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.ApplicationService.ProductTypeService
{
    public class ProductTypeService : BaseService, IProductTypeService
    {
        private readonly IUnitOfWork _storeUnitOfWork;
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IUnitOfWork storeUnitOfWork, IProductTypeRepository productTypeRepository, ErrorFactory errorFactory)
            : base(errorFactory)
        {
            _storeUnitOfWork = storeUnitOfWork;
            _productTypeRepository = productTypeRepository;
        }

        public async Task<IReadOnlyList<ProductType>> GetAll()
        {
            return
               await _productTypeRepository.GetAll();

        }
    }
}
