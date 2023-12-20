using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraProFinalAPI.Model;
using Microsoft.AspNetCore.Cors;
using LibraProFinalAPI.dto;
using Microsoft.Ajax.Utilities;

namespace LibraProFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Enable cors
    [EnableCors("appCors")]
    public class BookEvaluationsController : ControllerBase
    {
        private readonly LibraProFinalDataContext _context;

        public BookEvaluationsController(LibraProFinalDataContext context)
        {
            _context = context;
        }

        // GET: api/BookEvaluations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookEvaluation>>> GetBookEvaluations()
        {
          if (_context.BookEvaluations == null)
          {
              return NotFound();
          }
            return await _context.BookEvaluations.ToListAsync();
        }

        // GET: api/BookEvaluations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookEvaluation>> GetBookEvaluation(int id)
        {
          if (_context.BookEvaluations == null)
          {
              return NotFound();
          }
            var bookEvaluation = await _context.BookEvaluations.FindAsync(id);

            if (bookEvaluation == null)
            {
                return NotFound();
            }

            return bookEvaluation;
        }

        // PUT: api/BookEvaluations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookEvaluation(int id, BookEvaluation bookEvaluation)
        {
            if (id != bookEvaluation.BookEvaluationId)
            {
                return BadRequest();
            }

            _context.Entry(bookEvaluation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookEvaluationExists(id))
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

        // Method to increment the quantity of the book
        [NonAction]
        public int Incrementquantity(int id)
        {

            var user = _context.Books.Where(u => u.BookId == id).FirstOrDefault();
            if (user != null)
            {
                user.BookQuantity = user.BookQuantity + 1;
            }
            return user.BookQuantity;
        }

        // POST: api/BookEvaluations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("addEvaluation")]
        public async Task<ActionResult<BookEvaluation>> PostBookEvaluation([FromBody] AddBookEvaluation bookEvaluationDTO)
        {
            try
            {
                if (bookEvaluationDTO == null)
                {
                    return BadRequest("Invalid input data.");
                }

                var bookEvaluation = new BookEvaluation
                {
                    BookId = bookEvaluationDTO.BookId,
                    BookAuthor = bookEvaluationDTO.BookAuthor,
                    BookTitle = bookEvaluationDTO.BookTitle,
                    ConditionId = bookEvaluationDTO.ConditionId,
                    ConditionType = bookEvaluationDTO.ConditionType,
                    UserId = bookEvaluationDTO.UserId,
                    Status = "Evaluate",
                    EvaluationDate = DateTime.Now

                };

                if (bookEvaluation.ConditionType != "Poor Condition" && bookEvaluation.ConditionType != "Damaged Condition")
                {
                    Incrementquantity(bookEvaluation.BookId);
                }

                _context.BookEvaluations.Add(bookEvaluation);
                
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBookEvaluation", new { id = bookEvaluation.BookEvaluationId }, bookEvaluation);
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }


        // DELETE: api/BookEvaluations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookEvaluation(int id)
        {
            if (_context.BookEvaluations == null)
            {
                return NotFound();
            }
            var bookEvaluation = await _context.BookEvaluations.FindAsync(id);
            if (bookEvaluation == null)
            {
                return NotFound();
            }

            _context.BookEvaluations.Remove(bookEvaluation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookEvaluationExists(int id)
        {
            return (_context.BookEvaluations?.Any(e => e.BookEvaluationId == id)).GetValueOrDefault();
        }
    }
}
