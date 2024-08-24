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
    public class instructoresController : ControllerBase
    {
        private readonly ACADEMIAContext _context;

        public instructoresController(ACADEMIAContext context)
        {
            _context = context;
        }

        // GET: api/instructores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<instructores>>> GetInstructores()
        {
            return await _context.Instructores.ToListAsync();
        }

        // GET: api/instructores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<instructores>> Getinstructores(int id)
        {
            var instructores = await _context.Instructores.FindAsync(id);

            if (instructores == null)
            {
                return NotFound();
            }

            return instructores;
        }

        // PUT: api/instructores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putinstructores(int id, instructores instructores)
        {
            if (id != instructores.Id)
            {
                return BadRequest();
            }

            _context.Entry(instructores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!instructoresExists(id))
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

        // POST: api/instructores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<instructores>> Postinstructores(instructores instructores)
        {
            _context.Instructores.Add(instructores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getinstructores", new { id = instructores.Id }, instructores);
        }

        // DELETE: api/instructores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteinstructores(int id)
        {
            var instructores = await _context.Instructores.FindAsync(id);
            if (instructores == null)
            {
                return NotFound();
            }

            _context.Instructores.Remove(instructores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool instructoresExists(int id)
        {
            return _context.Instructores.Any(e => e.Id == id);
        }
    }
}
