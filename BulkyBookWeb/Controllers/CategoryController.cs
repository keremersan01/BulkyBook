using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BulkyContext _bulkyContext;
        public CategoryController(BulkyContext bulkyContext)
        {
            _bulkyContext = bulkyContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _bulkyContext.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The display order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _bulkyContext.Categories.Add(obj);
                _bulkyContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _bulkyContext.Categories.Find(id);
            //var categoryFromDb = _bulkyContext.Categories.FirstOrDefault(id);
            //var categoryFromDb = _bulkyContext.Categories.SingleOrDefault(id);


            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The display order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _bulkyContext.Categories.Update(obj);
                _bulkyContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _bulkyContext.Categories.Find(id);
            //var categoryFromDb = _bulkyContext.Categories.FirstOrDefault(id);
            //var categoryFromDb = _bulkyContext.Categories.SingleOrDefault(id);


            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _bulkyContext.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _bulkyContext.Categories.Remove(obj);
            _bulkyContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
