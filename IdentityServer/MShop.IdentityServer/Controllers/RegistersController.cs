using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MShop.IdentityServer.Dtos;
using MShop.IdentityServer.Models;
using System.Threading.Tasks;

namespace MShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
        {
            var values = new ApplicationUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
            };
            var result = await _userManager.CreateAsync(values, registerDto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı Kaydı Başarılı !");
            }
            return BadRequest("Bir Hata Oluştu");
        }
    }
}
