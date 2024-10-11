using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.UILayoutViewComponets
{
    public class UILayoutTopbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
