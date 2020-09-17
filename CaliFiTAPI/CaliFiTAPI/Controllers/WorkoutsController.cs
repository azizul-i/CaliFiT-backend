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
    public class WorkoutsController : ControllerBase
    {
        private readonly AppDatabase _context;

        public WorkoutsController(AppDatabase context)
        {
            _context = context;
        }

        // GET: api/Workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkout()
        {
            return await _context.Workout.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetPublicWorkouts()
        {
            var AllWorkouts = await _context.Workout.ToListAsync();
            List<Workout> workouts = new List<Workout>();

            if (AllWorkouts == null)
            {
                return NotFound();
            }

            for (int i = 0; i < AllWorkouts.Count; i++)
            {
                if (AllWorkouts[i].AddToLobby == true)
                {
                    workouts.Add(AllWorkouts[i]);
                }
            }

            return workouts;
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkoutById(int id)
        {
            var workout = await _context.Workout.FindAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        // post: api/Workouts/
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkoutByUserId(Workout workout)
        {
            var AllWorkouts = await _context.Workout.ToListAsync();
            List<Workout> workouts = new List<Workout>();

            if (AllWorkouts == null)
            {
                return NotFound();
            }

            for (int i = 0; i < AllWorkouts.Count; i++)
            {
                if (AllWorkouts[i].UserID == workout.UserID)
                {
                    workouts.Add(AllWorkouts[i]);
                }
            }

            return workouts;
        }

        // PUT: api/Workouts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkout(int id, Workout workout)
        {
            if (id != workout.WorkoutID)
            {
                return BadRequest();
            }

            _context.Entry(workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
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

        // POST: api/Workouts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Workout>> AddWorkout(Workout workout)
        {
            _context.Workout.Add(workout);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkout", new { id = workout.WorkoutID }, workout);
        }

        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Workout>> DeleteWorkout(int id)
        {
            var workout = await _context.Workout.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workout.Remove(workout);
            await _context.SaveChangesAsync();

            return workout;
        }

        private bool WorkoutExists(int id)
        {
            return _context.Workout.Any(e => e.WorkoutID == id);
        }
    }
}
