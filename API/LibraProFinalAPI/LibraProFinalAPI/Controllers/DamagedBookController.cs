using LibraProFinalAPI.dto;
using LibraProFinalAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraProFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Enable cors
    [EnableCors("appCors")]
    public class DamagedBookController : ControllerBase
    {

        private readonly ILogger<DamagedBookController> _logger; // Add this line

        public DamagedBookController(ILogger<DamagedBookController> logger) // Modify the constructor
        {
            _logger = logger;
        }

        private readonly LibraProFinalDataContext _context;

        public DamagedBookController(LibraProFinalDataContext context)
        {
            _context = context;
        }

        // GET: api/BookEvaluations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DamagedBook>>> GetEvaluations()
        {
            if (_context.BookEvaluations == null)
            {
                return NotFound();
            }
            return await _context.DamagedBooks.ToListAsync();
        }

        // GET: api/BookEvaluations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DamagedBook>> GeEvaluation(int id)
        {
            if (_context.BookEvaluations == null)
            {
                return NotFound();
            }
            var bookEvaluation = await _context.DamagedBooks.FindAsync(id);

            if (bookEvaluation == null)
            {
                return NotFound();
            }

            return bookEvaluation;
        }

        // PUT: api/BookEvaluations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluation(int id, DamagedBook bookEvaluation)
        {
            if (id != bookEvaluation.DamagedBookId)
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

        // POST: api/BookEvaluations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("addEvaluation")]
        public async Task<ActionResult<BookEvaluation>> PostBookEvaluation([FromBody] AddEvaluation bookEvaluationDTO)
        {
            try
            {
                if (bookEvaluationDTO == null)
                {
                    return BadRequest("Invalid input data.");
                }
                _logger.LogInformation($"Received API request with RepairPrice: {bookEvaluationDTO.RepairPrice}, ReplacePrice: {bookEvaluationDTO.ReplacePrice}");

                var bookEvaluation = new DamagedBook
                {
                    BookId = bookEvaluationDTO.BookId,
                    BookAuthor = bookEvaluationDTO.BookAuthor,
                    BookTitle = bookEvaluationDTO.BookTitle,
                    Status = bookEvaluationDTO.Status,
                    DamageType = bookEvaluationDTO.DamageType,
                    RepairPrice = bookEvaluationDTO.RepairPrice,
                    ReplacePrice = bookEvaluationDTO.ReplacePrice,
                    EvaluationDate = DateTime.Now
                };

                _context.DamagedBooks.Add(bookEvaluation);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Inserted DamagedBook with RepairPrice: {bookEvaluation.RepairPrice}, ReplacePrice: {bookEvaluation.ReplacePrice}");
                return CreatedAtAction("GetBookEvaluation", new { id = bookEvaluation.DamagedBookId }, bookEvaluation);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
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
            var bookEvaluation = await _context.DamagedBooks.FindAsync(id);
            if (bookEvaluation == null)
            {
                return NotFound();
            }

            _context.DamagedBooks.Remove(bookEvaluation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookEvaluationExists(int id)
        {
            return (_context.DamagedBooks?.Any(e => e.DamagedBookId == id)).GetValueOrDefault();
        }
    }
}
