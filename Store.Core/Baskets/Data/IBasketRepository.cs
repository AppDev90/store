using Store.Core.CustomerBaskets.Entity;
using System.Threading.Tasks;

namespace Store.Core.Baskets.Data
{
    public interface IBasketRepository
    {
        Task<string> CreateBasket(Basket basket);
        Task<bool> UpdateBasket(Basket basket);
        Task<Basket> GetBasket(string basketId);
        Task<bool> DeleteBasket(string basketId);
    }
}
