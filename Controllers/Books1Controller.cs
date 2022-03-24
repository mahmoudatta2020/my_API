using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_API.Models;

namespace my_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Books1Controller : ControllerBase
    {
        private readonly mahmoudAPIContext _context;

        public Books1Controller(mahmoudAPIContext context)
        {
            _context = context;
        }

        // GET: api/Books1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books1>>> GetBooks1(bool? instock, int? skip, int? take)
        {
            //return await _context.Books1.ToListAsync();
            var books = _context.Books1.AsQueryable();
            if(instock != null)
            {
                books = _context.Books1.Where(i => i.Quantity > 0);
            }
            if(skip != null)
            {
                //هنا هيجيب الكتب الي انا عايزها وهيسكب الباقي 
                books = books.Skip((int)skip);
            }
            if (take != null)
            {
                //هنا بجيب البيانات مجموعة مجموعة عشان ميعملش لود
                books = books.Take((int)take);
            }
            return await books.ToListAsync();
        }

        // GET: api/Books1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Books1>> GetBooks1(int id)
        {
            var books1 = await _context.Books1.FindAsync(id);

            if (books1 == null)
            {
                return NotFound();
            }

            return books1;
        }

        // PUT: api/Books1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooks1(int id, Books1 books1)
        {
            if (id != books1.BookId)
            {
                return BadRequest();
            }

            _context.Entry(books1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Books1Exists(id))
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

        // POST: api/Books1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Books1>> PostBooks1(Books1 books1)
        {
            _context.Books1.Add(books1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooks1", new { id = books1.BookId }, books1);
        }

        // DELETE: api/Books1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Books1>> DeleteBooks1(int id)
        {
            var books1 = await _context.Books1.FindAsync(id);
            if (books1 == null)
            {
                return NotFound();
            }

            _context.Books1.Remove(books1);
            await _context.SaveChangesAsync();

            return books1;
        }

        private bool Books1Exists(int id)
        {
            return _context.Books1.Any(e => e.BookId == id);
        }
    }
}
