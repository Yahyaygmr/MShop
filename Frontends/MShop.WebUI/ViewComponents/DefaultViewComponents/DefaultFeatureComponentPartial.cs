using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultFeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
