using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademiaBaile.Models;

namespace AcademiaBaile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ritmosController : ControllerBase
    {
        private readonly ACADEMIAContext _context;

        public ritmosController(ACADEMIAContext context)
        {
            _context = context;
        }

        // GET: api/ritmos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ritmos>>> GetRitmos()
        {
            return await _context.Ritmos.ToListAsync();
        }

        // GET: api/ritmos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ritmos>> Getritmos(int id)
        {
            var ritmos = await _context.Ritmos.FindAsync(id);

            if (ritmos == null)
            {
                return NotFound();
            }

            return ritmos;
        }

        // PUT: api/ritmos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putritmos(int id, ritmos ritmos)
        {
            if (id != ritmos.Id)
            {
                return BadRequest();
            }

            _context.Entry(ritmos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ritmosExists(id))
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

        // POST: api/ritmos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ritmos>> Postritmos(ritmos ritmos)
        {
            _context.Ritmos.Add(ritmos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getritmos", new { id = ritmos.Id }, ritmos);
        }

        // DELETE: api/ritmos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteritmos(int id)
        {
            var ritmos = await _context.Ritmos.FindAsync(id);
            if (ritmos == null)
            {
                return NotFound();
            }

            _context.Ritmos.Remove(ritmos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ritmosExists(int id)
        {
            return _context.Ritmos.Any(e => e.Id == id);
        }
    }
}
