using IntegracionesApi.Data;
using IntegracionesApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntegracionesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegracionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IntegracionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Integracion>>> GetIntegraciones()
        { 
           return await _context.Integraciones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Integracion>> GetIntegracionById(int Id)
        { 
           var integracion = _context.Integraciones.FindAsync(Id);
            if (integracion == null)
            { 
              return NotFound();
            }
            return Ok(integracion);
        
        }

        [HttpPost]
        public async Task<ActionResult<Integracion>> PostIntegracion(Integracion integracion)
        { 
            await _context.Integraciones.AddAsync(integracion);
            _context.SaveChanges();           
            return CreatedAtAction("GetIntegracion", new { id = integracion.Id }, integracion);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutIntegraciones(int id, Integracion integracion)
        {
            if (id != integracion.Id)
            { 
              return BadRequest();
            }
            _context.Entry(integracion).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegracionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }//put

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        { 
           var integracion = await _context.Integraciones.FindAsync(id);
            if (integracion == null)
            {
                return NotFound();
            }
             _context.Integraciones.Remove(integracion);
            await _context.SaveChangesAsync();
            return NoContent() ;        
        }

        private bool IntegracionExists(int id)
        {
            return _context.Integraciones.Any(e => e.Id == id);
        }
    }//class
}
