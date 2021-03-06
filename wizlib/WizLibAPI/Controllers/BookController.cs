﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wizlib_dataccess.data;
using wizlib_model.models;
using wizlib_model.ViewModels;

namespace WizLibAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetBook()
        {
            List<Book> books = await _context.Books.Include(u=>u.BookDetail).ToListAsync();
            string json = JsonConvert.SerializeObject(books, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                book.BookDetail = await _context.bookDetails.FirstOrDefaultAsync(u => u.BookDetail_Id == book.BookDetail_Id);
                return book;
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(string id, Book book)
        {
            if (id != book.Book_Id.ToString())
            {
                return BadRequest();
            }
            _context.Books.Update(book);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> PostBook([FromBody] IList<Book> books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.Books.AddRangeAsync(books);
            _context.SaveChanges();
            return Ok(books);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        private bool BookExists(string id)
        {
            return _context.Books.Any(e => e.Book_Id.ToString() == id);
        }
    }
}
