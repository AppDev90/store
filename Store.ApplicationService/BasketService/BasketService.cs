using Store.ApplicationService.Common;
using Store.ApplicationService.Factory;
using Store.Core.Baskets.Data;
using Store.Core.Baskets.ServiceContract;
using Store.Core.CustomerBaskets.Entity;
using System.Threading.Tasks;

namespace Store.ApplicationService.BasketService
{
    public class BasketService : BaseService, IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository, ErrorFactory errorFactory)
            : base(errorFactory)
        {
            _basketRepository = basketRepository;
        }

        public async Task<Basket> CreateBasket(Basket basket)
        {
            var createdBasketId = await _basketRepository.CreateBasket(basket);
            if (string.IsNullOrEmpty(createdBasketId))
                UnKnownError.Throw("Error in Creating Basket.");
            return await GetBasket(createdBasketId);
        }

        public async Task<Basket> UpdateBasket(Basket basket)
        {
            var updateDone = await _basketRepository.UpdateBasket(basket);
            if (!updateDone)
                UnKnownError.Throw("Error in Updating Basket.");
            return await GetBasket(basket.Id);
        }

        public async Task<bool> DeleteBasket(string basketId)
        {
            return await _basketRepository.DeleteBasket(basketId);
        }

        public async Task<Basket> GetBasket(string basketId)
        {
            var basket = await _basketRepository.GetBasket(basketId);
            if (basket == null)
                NotFoundError.Throw("Basket");
            return basket;
        }
    }
}
