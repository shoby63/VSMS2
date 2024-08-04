using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.models;
using api.DTOS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRepresentativesController : ControllerBase
    {
        private readonly PrimeAutomobilesDbContext _context;

        public ServiceRepresentativesController(PrimeAutomobilesDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceRepresentatives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRepresentativeDTO>>> GetServiceRepresentatives()
        {
            return await _context.ServiceRepresentatives
                .Select(sr => new ServiceRepresentativeDTO
                {
                    ServiceRepresentativeID = sr.ServiceRepresentativeId,
                    Name = sr.Name,
                    Email = sr.Email
                }).ToListAsync();
        }

        // GET: api/ServiceRepresentatives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRepresentativeDTO>> GetServiceRepresentative(int id)
        {
            var serviceRepresentative = await _context.ServiceRepresentatives
                .FirstOrDefaultAsync(sr => sr.ServiceRepresentativeId == id);

            if (serviceRepresentative == null)
            {
                return NotFound();
            }

            var serviceRepresentativeDTO = new ServiceRepresentativeDTO
            {
                ServiceRepresentativeID = serviceRepresentative.ServiceRepresentativeId,
                Name = serviceRepresentative.Name,
                Email = serviceRepresentative.Email
            };

            return serviceRepresentativeDTO;
        }

        // PUT: api/ServiceRepresentatives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceRepresentative(int id, ServiceRepresentativeDTO serviceRepresentativeDTO)
        {
            if (id != serviceRepresentativeDTO.ServiceRepresentativeID)
            {
                return BadRequest();
            }

            var serviceRepresentative = await _context.ServiceRepresentatives.FindAsync(id);
            if (serviceRepresentative == null)
            {
                return NotFound();
            }

            serviceRepresentative.Name = serviceRepresentativeDTO.Name;
            serviceRepresentative.Email = serviceRepresentativeDTO.Email;

            _context.Entry(serviceRepresentative).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceRepresentativeExists(id))
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

        // POST: api/ServiceRepresentatives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceRepresentativeDTO>> PostServiceRepresentative(ServiceRepresentativeDTO serviceRepresentativeDTO)
        {
            var serviceRepresentative = new ServiceRepresentative
            {
                Name = serviceRepresentativeDTO.Name,
                Email = serviceRepresentativeDTO.Email
            };

            _context.ServiceRepresentatives.Add(serviceRepresentative);
            await _context.SaveChangesAsync();

            serviceRepresentativeDTO.ServiceRepresentativeID = serviceRepresentative.ServiceRepresentativeId;

            return CreatedAtAction(nameof(GetServiceRepresentative), new { id = serviceRepresentativeDTO.ServiceRepresentativeID }, serviceRepresentativeDTO);
        }

        // DELETE: api/ServiceRepresentatives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceRepresentative(int id)
        {
            var serviceRepresentative = await _context.ServiceRepresentatives.FindAsync(id);
            if (serviceRepresentative == null)
            {
                return NotFound();
            }

            _context.ServiceRepresentatives.Remove(serviceRepresentative);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceRepresentativeExists(int id)
        {
            return _context.ServiceRepresentatives.Any(e => e.ServiceRepresentativeId == id);
        }
    }
}
