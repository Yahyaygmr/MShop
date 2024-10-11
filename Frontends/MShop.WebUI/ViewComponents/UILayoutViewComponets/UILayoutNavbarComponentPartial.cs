using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.UILayoutViewComponets
{
    public class UILayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
