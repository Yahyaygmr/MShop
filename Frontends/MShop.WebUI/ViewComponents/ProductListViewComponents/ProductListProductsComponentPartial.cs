﻿using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class ProductListProductsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
