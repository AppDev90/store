﻿using Microsoft.AspNetCore.Mvc;
using Store.Core.Products.Dto;
using Store.Core.Products.Dto.Query;
using Store.Core.Products.ServiceContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.API.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductsWithDetail>>> GetProducts
            ([FromQuery]FilterDto filterDto)
        {
            return Ok(await _productService.GetPdoducts(filterDto));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<ProductsWithDetail>>> GetProduct(int id)
        {
            return Ok(await _productService.GetWithDetail(id));
        }
    }
}
