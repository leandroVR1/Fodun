using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fodun.Data;
using Fodun.Models;
using System.Threading.Tasks;

namespace Fodun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SedesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sedes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sede>>> GetSedes()
        {
            return await _context.Sedes.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Sede>> GetSede(int id)
        {
            var sede = await _context.Sedes.FindAsync(id);

            if (sede == null)
            {
                return NotFound();
            }

            return sede;
        }

        [HttpPost]
        public async Task<ActionResult<Sede>> PostSede(Sede sede)
        {
            _context.Sedes.Add(sede);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSede), new { id = sede.SedeId }, sede);
        }

      
  

        
    }
}
