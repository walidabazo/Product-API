using Product.Core.Entities;
using Product.Core.Interface;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basketid)
        {
           return await _database.KeyDeleteAsync(basketid);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketid)
        {
            var data =await _database.StringGetAsync(basketid);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket)
        {
            var _basket = await _database.StringSetAsync(customerBasket.Id,JsonSerializer.Serialize(customerBasket),TimeSpan.FromDays(30));
            if (!_basket) return null;
            return await GetBasketAsync(customerBasket.Id);
            
        }
    }
}
