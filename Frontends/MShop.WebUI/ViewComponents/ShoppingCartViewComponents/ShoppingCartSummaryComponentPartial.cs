using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class ShoppingCartSummaryComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
