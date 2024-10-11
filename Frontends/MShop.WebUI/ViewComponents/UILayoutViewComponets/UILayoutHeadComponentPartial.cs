using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.UILayoutViewComponets
{
    public class UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
