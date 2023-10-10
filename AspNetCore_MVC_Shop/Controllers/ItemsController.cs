using Microsoft.AspNetCore.Mvc;
using DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using DataAccess.Entities;

namespace AspNetCore_MVC_Shop.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ShopDbContext context;

        public ItemsController(ShopDbContext context)
        {
            this.context = context;
        }

        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(context.Categories.ToList(), "Id", "Name");
        }

        public IActionResult Index()
        {
            return View(context.Items.Include(i => i.Category).ToList());
        }

        public IActionResult Delete(int itemId)
        {
            var item = context.Items.Find(itemId);

            if (item == null)
                return NotFound();

            context.Items.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadCategories();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();

                return View(item);
            }

            context.Items.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int itemId)
        {
            var item = context.Items.Find(itemId);

            if (item == null)
                return NotFound();

            LoadCategories();

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();

                return View(item);
            }

            context.Items.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Info(int itemId)
        {
            return View();
        }
    }
}
