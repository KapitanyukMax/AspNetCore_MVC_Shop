using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AspNetCore_MVC_Shop.Helpers;
using System.Linq;

namespace AspNetCore_MVC_Shop.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly ShopDbContext _context;

        public FavoritesController(ShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var favoriteItemIds = HttpContext.Session.Get<List<int>>("favorite_items");

            if (favoriteItemIds == null)
                favoriteItemIds = new();

            return View(_context.Items.Where(i => favoriteItemIds.Contains(i.Id)).ToList());
        }

        public IActionResult Add(int itemId)
        {
            var favoriteItemIds = HttpContext.Session.Get<List<int>>("favorite_items") ?? new();
            favoriteItemIds.Add(itemId);

            HttpContext.Session.Set("favorite_items", favoriteItemIds);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int itemId)
        {
            var favoriteItemIds = HttpContext.Session.Get<List<int>>("favorite_items") ?? new();
            favoriteItemIds.Remove(itemId);

            HttpContext.Session.Set("favorite_items", favoriteItemIds);
            return RedirectToAction("Index");
        }
    }
}
