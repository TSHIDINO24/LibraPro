﻿using System;
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
    public class ConditionsController : ControllerBase
    {
        private readonly LibraProFinalDataContext _context;

        public ConditionsController(LibraProFinalDataContext context)
        {
            _context = context;
        }

        // GET: api/Conditions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condition>>> GetConditions()
        {
          if (_context.Conditions == null)
          {
              return NotFound();
          }
            return await _context.Conditions.ToListAsync();
        }

        // GET: api/Conditions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Condition>> GetCondition(int id)
        {
          if (_context.Conditions == null)
          {
              return NotFound();
          }
            var condition = await _context.Conditions.FindAsync(id);

            if (condition == null)
            {
                return NotFound();
            }

            return condition;
        }

        // PUT: api/Conditions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondition(int id, Condition condition)
        {
            if (id != condition.ConditionId)
            {
                return BadRequest();
            }

            _context.Entry(condition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionExists(id))
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

        // POST: api/Conditions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Condition>> PostCondition(Condition condition)
        {
          if (_context.Conditions == null)
          {
              return Problem("Entity set 'LibraProFinalDataContext.Conditions'  is null.");
          }
            _context.Conditions.Add(condition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCondition", new { id = condition.ConditionId }, condition);
        }

        // DELETE: api/Conditions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondition(int id)
        {
            if (_context.Conditions == null)
            {
                return NotFound();
            }
            var condition = await _context.Conditions.FindAsync(id);
            if (condition == null)
            {
                return NotFound();
            }

            _context.Conditions.Remove(condition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConditionExists(int id)
        {
            return (_context.Conditions?.Any(e => e.ConditionId == id)).GetValueOrDefault();
        }
    }
}
