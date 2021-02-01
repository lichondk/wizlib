using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wizlib_dataccess.data;
using wizlib_model.models;

namespace wizlib.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objList = _db.categories.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Category obj = new Category();
            if (id == null)
            {
                return View(obj);
            }

            obj = _db.categories.FirstOrDefault(u => u.Category_Id == id);
            if(obj== null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Category_Id == 0)
                {
                    _db.categories.Add(obj);
                }
                else
                {
                    _db.categories.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var obj = _db.categories.FirstOrDefault(u => u.Category_Id == id);
            _db.categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> catList = new List<Category>();
            for (int i = 1; i <= 2; i++)
            {
                catList.Add(new Category { Name = Guid.NewGuid().ToString() });
                //_db.categories.Add(new Category { Name = Guid.NewGuid().ToString() });
            }
            _db.categories.AddRange(catList);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            List<Category> catList = new List<Category>();
            for (int i = 1; i <= 5; i++)
            {
                catList.Add(new Category { Name = Guid.NewGuid().ToString() });
                //_db.categories.Add(new Category { Name = Guid.NewGuid().ToString() });
            }
            _db.categories.AddRange(catList);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            IEnumerable<Category> catList = _db.categories.OrderByDescending(u => u.Category_Id).Take(2).ToList();
            _db.categories.RemoveRange(catList);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            IEnumerable<Category> catList = _db.categories.OrderByDescending(u => u.Category_Id).Take(5).ToList();
            _db.categories.RemoveRange(catList);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
