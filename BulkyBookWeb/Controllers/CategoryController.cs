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
    }
}
