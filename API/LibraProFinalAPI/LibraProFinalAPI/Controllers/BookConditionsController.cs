using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraProFinalAPI.Model;
using Microsoft.AspNetCore.Cors;

namespace LibraProFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Enable cors
    [EnableCors("appCors")]
    public class BookConditionsController : ControllerBase
    {
        private readonly LibraProFinalDataContext _context;

        public BookConditionsController(LibraProFinalDataContext context)
        {
            _context = context;
        }

        // GET: api/BookConditions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCondition>>> GetBookConditions()
        {
          if (_context.BookConditions == null)
          {
              return NotFound();
          }
            return await _context.BookConditions.ToListAsync();
        }

        // GET: api/BookConditions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookCondition>> GetBookCondition(int id)
        {
          if (_context.BookConditions == null)
          {
              return NotFound();
          }
            var bookCondition = await _context.BookConditions.FindAsync(id);

            if (bookCondition == null)
            {
                return NotFound();
            }

            return bookCondition;
        }

        // PUT: api/BookConditions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookCondition(int id, BookCondition bookCondition)
        {
            if (id != bookCondition.BookConditionId)
            {
                return BadRequest();
            }

            _context.Entry(bookCondition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookConditionExists(id))
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

        // POST: api/BookConditions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookCondition>> PostBookCondition(BookCondition bookCondition)
        {
          if (_context.BookConditions == null)
          {
              return Problem("Entity set 'LibraProFinalDataContext.BookConditions'  is null.");
          }
            _context.BookConditions.Add(bookCondition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookCondition", new { id = bookCondition.BookConditionId }, bookCondition);
        }

        // DELETE: api/BookConditions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookCondition(int id)
        {
            if (_context.BookConditions == null)
            {
                return NotFound();
            }
            var bookCondition = await _context.BookConditions.FindAsync(id);
            if (bookCondition == null)
            {
                return NotFound();
            }

            _context.BookConditions.Remove(bookCondition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookConditionExists(int id)
        {
            return (_context.BookConditions?.Any(e => e.BookConditionId == id)).GetValueOrDefault();
        }
    }
}
