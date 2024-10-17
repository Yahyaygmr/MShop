using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class ShoppingCartProductListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
