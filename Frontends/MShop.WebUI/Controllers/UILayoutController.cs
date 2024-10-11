using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
