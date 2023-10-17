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
        private readonly ShopDbContext _context;

        public ItemsController(ShopDbContext context)
        {
            _context = context;
        }

        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
        }

        public IActionResult Index()
        {
            return View(_context.Items.Include(i => i.Category).ToList());
        }

        public IActionResult Delete(int itemId)
        {
            var item = _context.Items.Find(itemId);

            if (item == null)
                return NotFound();

            _context.Items.Remove(item);
            _context.SaveChanges();

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

            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int itemId)
        {
            var item = _context.Items.Find(itemId);

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

            _context.Items.Update(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Info(int itemId)
        {
            return View();
        }
    }
}
