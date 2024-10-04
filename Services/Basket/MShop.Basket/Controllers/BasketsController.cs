using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.Basket.Dtos;
using MShop.Basket.Services;
using MShop.Basket.Services.LoginServices;

namespace MShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto dto)
        {
            dto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(dto);
            return Ok("Sepetteki Değişiklikler Kaydedildi !");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepet Başarıyla Silindi");
        }
    }
}
