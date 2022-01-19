using Microsoft.AspNetCore.Mvc;
using Store.Core.ProductTypes.Entity;
using Store.Core.ProductTypes.ServiceContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.API.Controllers
{

    public class ProductTypeController : BaseApiController
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {
            return Ok(await _productTypeService.GetAll());
        }
    }
}
