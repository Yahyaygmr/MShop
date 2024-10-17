using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class ProductListColorFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
