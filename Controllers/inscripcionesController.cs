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
    public class inscripcionesController : ControllerBase
    {
        private readonly ACADEMIAContext _context;

        public inscripcionesController(ACADEMIAContext context)
        {
            _context = context;
        }

        // GET: api/inscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<inscripciones>>> GetInscripciones()
        {
            return await _context.Inscripciones.ToListAsync();
        }

        // GET: api/inscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<inscripciones>> Getinscripciones(int id)
        {
            var inscripciones = await _context.Inscripciones.FindAsync(id);

            if (inscripciones == null)
            {
                return NotFound();
            }

            return inscripciones;
        }

        // PUT: api/inscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putinscripciones(int id, inscripciones inscripciones)
        {
            if (id != inscripciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(inscripciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!inscripcionesExists(id))
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

        // POST: api/inscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<inscripciones>> Postinscripciones(inscripciones inscripciones)
        {
            _context.Inscripciones.Add(inscripciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getinscripciones", new { id = inscripciones.Id }, inscripciones);
        }

        // DELETE: api/inscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteinscripciones(int id)
        {
            var inscripciones = await _context.Inscripciones.FindAsync(id);
            if (inscripciones == null)
            {
                return NotFound();
            }

            _context.Inscripciones.Remove(inscripciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool inscripcionesExists(int id)
        {
            return _context.Inscripciones.Any(e => e.Id == id);
        }
    }
}
