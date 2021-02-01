using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wizlib_dataccess.data;
using wizlib_model.models;

namespace wizlib.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Author> objList = _db.Authors.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Author obj = new Author();
            if(id == null)
            {
                return View(obj);
            }
            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if(obj== null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.Author_Id == 0)
                {
                    _db.Authors.Add(obj);
                }
                else
                {
                    _db.Authors.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            _db.Authors.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
