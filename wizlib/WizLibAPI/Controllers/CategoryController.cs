﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wizlib_dataccess.data;
using wizlib_model.models;

namespace WizLibAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.categories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.categories.FindAsync(id);
            if(category != null)
            {
                return category;
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(string id, Category category)
        {
            if (id != category.Category_Id.ToString())
            {
                return BadRequest();
            }
            _context.categories.Update(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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
        public async Task<ActionResult> PostCategory([FromBody] IList<Category> categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.categories.AddRangeAsync(categories);
            _context.SaveChanges();
            return Ok(categories);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            Category cat = await _context.categories.FindAsync(id);
            if (cat != null)
            {
                _context.categories.Remove(cat);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        private bool CategoryExists(string id)
        {
            return _context.categories.Any(e => e.Category_Id.ToString() == id);
        }
    }
}
