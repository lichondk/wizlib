using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wizlib_dataccess.data;
using wizlib_model.models;
using wizlib_model.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace wizlib.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Book> objList = _db.Books.Include(u => u.Publisher).ToList();
            //foreach (var obj in objList)
            //{
            //    //least effecient
            //    //obj.Publisher = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == obj.Publisher_Id);
                
            //    //explicit loading
            //    _db.Entry(obj).Reference(u => u.Publisher).Load();
            //}
            return View(objList);
        }

       public IActionResult Upsert(int? id)
        {
            BookViewModel obj = new BookViewModel();
            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });

            if (id == null)
            {
                return View(obj);
            }

            obj.Book = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            if(obj== null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookViewModel obj)
        {
                if (obj.Book.Book_Id == 0)
                {
                    _db.Books.Add(obj.Book);
                }
                else
                {
                    _db.Books.Update(obj.Book);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var obj = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            _db.Books.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            BookViewModel obj = new BookViewModel();

            if (id == null)
            {
                return View(obj);
            }

            obj.Book = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            obj.Book.BookDetail = _db.bookDetails.FirstOrDefault(u => u.BookDetail_Id == obj.Book.BookDetail_Id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookViewModel obj)
        {
            if (obj.Book.BookDetail.BookDetail_Id == 0)
            {
                _db.bookDetails.Add(obj.Book.BookDetail);
                _db.SaveChanges();
                
                var BookFromDb = _db.Books.Include(u=>u.BookDetail).FirstOrDefault(u => u.Book_Id == obj.Book.Book_Id);
                _db.SaveChanges();
            }
            else
            {
                _db.bookDetails.Update(obj.Book.BookDetail);
                _db.SaveChanges();
            }
        
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PlayGround()
        {
            var bookTemp = _db.Books.FirstOrDefault();
            bookTemp.Price = 100;

            var bookCollection = _db.Books;
            double totalPrice = 0;

            foreach (var book in bookCollection)
            {
                totalPrice += book.Price;
            }

            var bookList = _db.Books.ToList();
            foreach (var book in bookList)
            {
                totalPrice += book.Price;
            }

            var bookCollection2 = _db.Books;
            var bookCount1 = bookCollection2.Count();

            var bookCount2 = _db.Books.Count();

            //updating Related Data
            var bookTemp1 = _db.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Book_Id == 4);
            bookTemp1.BookDetail.NumberOfChapters = 2222;
            _db.Books.Update(bookTemp1);
            _db.SaveChanges();

            var bookTemp2 = _db.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Book_Id == 4);
            bookTemp2.BookDetail.Wegith = 333;
            _db.Books.Attach(bookTemp2);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
