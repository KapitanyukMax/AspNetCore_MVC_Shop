using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AspNetCore_MVC_Shop.Helpers;

namespace AspNetCore_MVC_Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopDbContext _context;

        public CartController(ShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cartItemIds = HttpContext.Session.Get<List<int>>("cart_items");

            if (cartItemIds == null)
                cartItemIds = new();

            return View(_context.Items.Where(i => cartItemIds.Contains(i.Id)).ToList());
        }

        public IActionResult Add(int itemId)
        {
            var cartItemIds = HttpContext.Session.Get<List<int>>("cart_items") ?? new();
            cartItemIds.Add(itemId);

            HttpContext.Session.Set("cart_items", cartItemIds);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int itemId)
        {
            var cartItemIds = HttpContext.Session.Get<List<int>>("cart_items") ?? new();
            cartItemIds.Remove(itemId);

            HttpContext.Session.Set("cart_items", cartItemIds);
            return RedirectToAction("Index");
        }
    }
}
