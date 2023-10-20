using AspNetCore_MVC_Shop.Helpers;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace AspNet_MVC_SPU111.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ShopDbContext _context;

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public OrdersController(ShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders.Where(order => order.UserId == CurrentUserId).ToList();

            return View(orders);
        }

        public IActionResult Create()
        {
            List<int>? cartItemIds = HttpContext.Session.Get<List<int>>("cart_items");

            List<Item> items = new();

            if (cartItemIds != null)
                items = _context.Items.Where(x => cartItemIds.Contains(x.Id)).ToList();

            var order = new Order()
            {
                Date = DateTime.Now,
                UserId = CurrentUserId,
                Items = items,
                TotalPrice = items.Sum(x => x.Price)
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            HttpContext.Session.Remove("cart_items");

            return RedirectToAction("Index");
        }
    }
}