using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaliFiTAPI.Models;

namespace CaliFiTAPI.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class CompletedsController : ControllerBase
    {
        private readonly AppDatabase _context;

        public CompletedsController(AppDatabase context)
        {
            _context = context;
        }

        // GET: api/Completeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Completed>>> GetCompleted()
        {
            return await _context.Completed.ToListAsync();
        }

        // GET: api/Completeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Completed>> GetCompletedById(int id)
        {
            var completed = await _context.Completed.FindAsync(id);

            if (completed == null)
            {
                return NotFound();
            }

            return completed;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Completed>>> GetCompletedByUserId(int id)
        {
            var AllCompleted = await _context.Completed.ToListAsync();
            List<Completed> completedList = new List<Completed>();

            if (AllCompleted == null)
            {
                return NotFound();
            }

            for (int i = 0; i < AllCompleted.Count; i++)
            {
                if (AllCompleted[i].UserID == id)
                {
                    completedList.Add(AllCompleted[i]);
                }
            }

            return completedList;
        }

        // PUT: api/Completeds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompleted(int id, Completed completed)
        {
            if (id != completed.CompletedID)
            {
                return BadRequest();
            }

            _context.Entry(completed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompletedExists(id))
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

        // POST: api/Completeds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Completed>> AddCompleted(Completed completed)
        {
            _context.Completed.Add(completed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompleted", new { id = completed.CompletedID }, completed);
        }

        // DELETE: api/Completeds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Completed>> DeleteCompleted(int id)
        {
            var completed = await _context.Completed.FindAsync(id);
            if (completed == null)
            {
                return NotFound();
            }

            _context.Completed.Remove(completed);
            await _context.SaveChangesAsync();

            return completed;
        }

        private bool CompletedExists(int id)
        {
            return _context.Completed.Any(e => e.CompletedID == id);
        }
    }
}
