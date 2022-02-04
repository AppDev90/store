using AutoMapper;
using Store.ApplicationService.Common;
using Store.ApplicationService.Factory;
using Store.Core.Baskets.Data;
using Store.Core.Baskets.Dto;
using Store.Core.Baskets.ServiceContract;
using Store.Core.CustomerBaskets.Entity;
using System.Threading.Tasks;

namespace Store.ApplicationService.BasketService
{
    public class BasketService : BaseService, IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository basketRepository, IMapper mapper, ErrorFactory errorFactory)
            : base(errorFactory)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<Basket> CreateBasket(BasketDto basketDto)
        {
            Basket basket = MaptToBasket(basketDto);
            var createdBasketId = await _basketRepository.CreateBasket(basket);
            if (string.IsNullOrEmpty(createdBasketId))
                UnKnownError.Throw("Error in Creating Basket.");
            return await GetBasket(createdBasketId);
        }

        private Basket MaptToBasket(BasketDto basketDto)
        {
            return _mapper.Map<Basket>(basketDto);
        }

        public async Task<Basket> UpdateBasket(BasketDto basketDto)
        {
            Basket basket = MaptToBasket(basketDto);
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
