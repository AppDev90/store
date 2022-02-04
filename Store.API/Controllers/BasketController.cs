using Microsoft.AspNetCore.Mvc;
using Store.Core.Baskets.Dto;
using Store.Core.Baskets.ServiceContract;
using Store.Core.CustomerBaskets.Entity;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Basket>> CreateBasket(BasketDto basketDto)
        {
            return Ok(await _basketService.CreateBasket(basketDto));
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Basket>> UpdateBasket(BasketDto basketDto)
        {
            return Ok(await _basketService.UpdateBasket(basketDto));
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasket(string id)
        {
            return Ok(await _basketService.GetBasket(id));
        }


        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _basketService.DeleteBasket(id);
        }

    }
}
