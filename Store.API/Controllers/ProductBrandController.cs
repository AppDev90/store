using Microsoft.AspNetCore.Mvc;
using Store.Core.ProductBrands.Entity;
using Store.Core.ProductBrands.ServiceContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    public class ProductBrandController : BaseApiController
    {
        private readonly IProductBrandService _productBrandService;

        public ProductBrandController(IProductBrandService productBrandService)
        {
            _productBrandService = productBrandService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            return Ok(await _productBrandService.GetAll());
        }

    }
}
