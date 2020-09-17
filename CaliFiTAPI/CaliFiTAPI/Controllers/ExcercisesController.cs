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
    public class ExcercisesController : ControllerBase
    {
        private readonly AppDatabase _context;

        public ExcercisesController(AppDatabase context)
        {
            _context = context;
        }

        // GET: api/Excercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Excercise>>> GetExcercise()
        {
            return await _context.Excercise.ToListAsync();
        }

        // GET: api/Excercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Excercise>> GetExcerciseById(int id)
        {
            var excercise = await _context.Excercise.FindAsync(id);

            if (excercise == null)
            {
                return NotFound();
            }

            return excercise;
        }

        // GET: api/Excercises/5
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Excercise>>> GetExcercisesByWorkoutId(Excercise excercise)
        {
            var AllExcercises = await _context.Excercise.ToListAsync();
            List<Excercise> excercises = new List<Excercise>();

            if (AllExcercises == null)
            {
                return NotFound();
            }

            for (int i = 0; i < AllExcercises.Count; i++)
            {
                if (AllExcercises[i].WorkoutID == excercise.WorkoutID)
                {
                    excercises.Add(AllExcercises[i]);
                }
            }

            return excercises;
        }

        // PUT: api/Excercises/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExcercise(int id, Excercise excercise)
        {
            if (id != excercise.ExcerciseID)
            {
                return BadRequest();
            }

            _context.Entry(excercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExcerciseExists(id))
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

        // POST: api/Excercises
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Excercise>> AddExcercise(Excercise excercise)
        {
            _context.Excercise.Add(excercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExcercise", new { id = excercise.ExcerciseID }, excercise);
        }

        // DELETE: api/Excercises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Excercise>> DeleteExcercise(int id)
        {
            var excercise = await _context.Excercise.FindAsync(id);
            if (excercise == null)
            {
                return NotFound();
            }

            _context.Excercise.Remove(excercise);
            await _context.SaveChangesAsync();

            return excercise;
        }

        private bool ExcerciseExists(int id)
        {
            return _context.Excercise.Any(e => e.ExcerciseID == id);
        }
    }
}
