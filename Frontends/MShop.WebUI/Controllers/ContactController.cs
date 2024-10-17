using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
