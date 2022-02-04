using Store.Core.Baskets.Dto;
using Store.Core.CustomerBaskets.Entity;
using System.Threading.Tasks;

namespace Store.Core.Baskets.ServiceContract
{
    public interface IBasketService
    {
        Task<Basket> CreateBasket(BasketDto basket);
        Task<Basket> UpdateBasket(BasketDto basket);
        Task<Basket> GetBasket(string basketId);
        Task<bool> DeleteBasket(string basketId);
    }
}
