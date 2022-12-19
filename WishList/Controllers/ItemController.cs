using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Item> viewData = _context.Items.ToList();
            return View("Index", viewData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public RedirectToActionResult Delete(int Id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == Id);
            _context.Items.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
