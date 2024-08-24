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
    public class pagosController : ControllerBase
    {
        private readonly ACADEMIAContext _context;

        public pagosController(ACADEMIAContext context)
        {
            _context = context;
        }

        // GET: api/pagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<pagos>>> GetPagos()
        {
            return await _context.Pagos.ToListAsync();
        }

        // GET: api/pagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<pagos>> Getpagos(int id)
        {
            var pagos = await _context.Pagos.FindAsync(id);

            if (pagos == null)
            {
                return NotFound();
            }

            return pagos;
        }

        // PUT: api/pagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpagos(int id, pagos pagos)
        {
            if (id != pagos.Id)
            {
                return BadRequest();
            }

            _context.Entry(pagos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pagosExists(id))
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

        // POST: api/pagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<pagos>> Postpagos(pagos pagos)
        {
            _context.Pagos.Add(pagos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpagos", new { id = pagos.Id }, pagos);
        }

        // DELETE: api/pagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepagos(int id)
        {
            var pagos = await _context.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }

            _context.Pagos.Remove(pagos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool pagosExists(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}
