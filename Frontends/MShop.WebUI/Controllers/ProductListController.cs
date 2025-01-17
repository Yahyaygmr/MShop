﻿using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string? id)
        {
            ViewBag.categoryId = id;
            return View();
        }
        public IActionResult Detail(string id)
        {
            ViewBag.productId = id;
            return View();
        }
    }
}
