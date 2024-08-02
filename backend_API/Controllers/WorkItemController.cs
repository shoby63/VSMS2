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
    public class WorkItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkItem>>> GetWorkItems()
        {
            return await _context.WorkItems.ToListAsync();
        }

        // GET: api/WorkItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkItem>> GetWorkItem(int id)
        {
            var workItem = await _context.WorkItems.FindAsync(id);

            if (workItem == null)
            {
                return NotFound();
            }

            return workItem;
        }

        // PUT: api/WorkItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkItem(int id, WorkItem workItem)
        {
            if (id != workItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(workItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkItemExists(id))
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

        // POST: api/WorkItems
        [HttpPost]
        public async Task<ActionResult<WorkItem>> PostWorkItem(WorkItem workItem)
        {
            _context.WorkItems.Add(workItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkItem), new { id = workItem.Id }, workItem);
        }

        // DELETE: api/WorkItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkItem(int id)
        {
            var workItem = await _context.WorkItems.FindAsync(id);
            if (workItem == null)
            {
                return NotFound();
            }

            _context.WorkItems.Remove(workItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkItemExists(int id)
        {
            return _context.WorkItems.Any(e => e.Id == id);
        }
    }
}
