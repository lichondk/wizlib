using Microsoft.AspNetCore.Mvc;
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
    public class BookdetailController: Controller
    {
        private readonly ApplicationDbContext _context;
        public BookdetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostBookDetail([FromBody] IList<BookDetail> bookDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.bookDetails.AddRangeAsync(bookDetails);
            _context.SaveChanges();
            return Ok(bookDetails);
        }
    }
}
