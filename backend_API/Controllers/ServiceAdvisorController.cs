using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_API.Data;
using backend_API.Model;
namespace backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAdvisorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceAdvisorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceAdvisors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceAdvisor>>> GetServiceAdvisors()
        {
            return await _context.ServiceAdvisors.ToListAsync();
        }

        // GET: api/ServiceAdvisors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceAdvisor>> GetServiceAdvisor(int id)
        {
            var serviceAdvisor = await _context.ServiceAdvisors.FindAsync(id);

            if (serviceAdvisor == null)
            {
                return NotFound();
            }

            return serviceAdvisor;
        }

        // PUT: api/ServiceAdvisors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceAdvisor(int id, ServiceAdvisor serviceAdvisor)
        {
            if (id != serviceAdvisor.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceAdvisor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceAdvisorExists(id))
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

        // POST: api/ServiceAdvisors
        [HttpPost]
        public async Task<ActionResult<ServiceAdvisor>> PostServiceAdvisor(ServiceAdvisor serviceAdvisor)
        {
            _context.ServiceAdvisors.Add(serviceAdvisor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceAdvisor), new { id = serviceAdvisor.Id }, serviceAdvisor);
        }

        // DELETE: api/ServiceAdvisors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceAdvisor(int id)
        {
            var serviceAdvisor = await _context.ServiceAdvisors.FindAsync(id);
            if (serviceAdvisor == null)
            {
                return NotFound();
            }

            _context.ServiceAdvisors.Remove(serviceAdvisor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceAdvisorExists(int id)
        {
            return _context.ServiceAdvisors.Any(e => e.Id == id);
        }
    }
}
