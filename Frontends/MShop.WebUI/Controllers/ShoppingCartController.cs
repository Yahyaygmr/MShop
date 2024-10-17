using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
