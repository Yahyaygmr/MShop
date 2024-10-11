using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
