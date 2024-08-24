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
    public class clasesController : ControllerBase
    {
        private readonly ACADEMIAContext _context;

        public clasesController(ACADEMIAContext context)
        {
            _context = context;
        }

        // GET: api/clases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<clases>>> GetClases()
        {
            return await _context.Clases.ToListAsync();
        }

        // GET: api/clases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<clases>> Getclases(int id)
        {
            var clases = await _context.Clases.FindAsync(id);

            if (clases == null)
            {
                return NotFound();
            }

            return clases;
        }

        // PUT: api/clases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putclases(int id, clases clases)
        {
            if (id != clases.Id)
            {
                return BadRequest();
            }

            _context.Entry(clases).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clasesExists(id))
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

        // POST: api/clases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<clases>> Postclases(clases clases)
        {
            _context.Clases.Add(clases);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getclases", new { id = clases.Id }, clases);
        }

        // DELETE: api/clases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteclases(int id)
        {
            var clases = await _context.Clases.FindAsync(id);
            if (clases == null)
            {
                return NotFound();
            }

            _context.Clases.Remove(clases);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clasesExists(int id)
        {
            return _context.Clases.Any(e => e.Id == id);
        }
    }
}
