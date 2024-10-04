using MShop.Basket.Dtos;
using MShop.Basket.Settings;
using StackExchange.Redis;
using System.Text.Json;

namespace MShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService redisService;

        public BasketService(RedisService redisService)
        {
            this.redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            RedisValue existBasket = await redisService.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket!)!;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
