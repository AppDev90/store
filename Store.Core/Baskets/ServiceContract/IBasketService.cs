using Store.Core.CustomerBaskets.Entity;
using System.Threading.Tasks;

namespace Store.Core.Baskets.ServiceContract
{
    public interface IBasketService
    {
        Task<Basket> CreateBasket(Basket basket);
        Task<Basket> UpdateBasket(Basket basket);
        Task<Basket> GetBasket(string basketId);
        Task<bool> DeleteBasket(string basketId);
    }
}
