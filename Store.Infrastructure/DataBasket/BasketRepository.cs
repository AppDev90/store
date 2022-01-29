using StackExchange.Redis;
using Store.Core.Baskets.Data;
using Store.Core.CustomerBaskets.Entity;
using Store.Infrastructure.Utility;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Infrastructure.DataBasket
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<string> CreateBasket(Basket basket)
        {
            basket.Id = UniqueCodeGenerator.GenerateBasketId();
            var setDone = await SetBasket(basket);
            return setDone ? basket.Id : null;
        }

        public async Task<bool> UpdateBasket(Basket basket)
        {
            return await SetBasket(basket);
        }

        private async Task<bool> SetBasket(Basket basket)
        {
            return await _database.StringSetAsync(basket.Id,
                JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
        }

        public async Task<bool> DeleteBasket(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<Basket> GetBasket(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(data);
        }
    }
}
