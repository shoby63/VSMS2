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
    public class WorkItemsController : ControllerBase
    {
        private readonly PrimeAutomobilesDbContext _context;

        public WorkItemsController(PrimeAutomobilesDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkItemDTO>>> GetWorkItems()
        {
            return await _context.WorkItems
                .Select(wi => new WorkItemDTO
                {
                    WorkItemID = wi.WorkItemId,
                    Description = wi.Description,
                    Cost = wi.Cost
                }).ToListAsync();
           

        }

        // GET: api/WorkItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkItemDTO>> GetWorkItem(int id)
        {
            var workItem = await _context.WorkItems
                .FirstOrDefaultAsync(wi => wi.WorkItemId == id);

            if (workItem == null)
            {
                return NotFound();
            }

            var workItemDTO = new WorkItemDTO
            {
                WorkItemID = workItem.WorkItemId,
                Description = workItem.Description,
                Cost = workItem.Cost
            };

            return workItemDTO;
        }

        // PUT: api/WorkItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkItem(int id, [FromBody] WorkItemDTO workItemDTO)
        {
            if (workItemDTO == null)
            {
                return BadRequest(new { error = "The workItemDTO field is required." });
            }

            if (id != workItemDTO.WorkItemID)
            {
                return BadRequest(new { error = "ID in URL and body do not match." });
            }

            var workItem = await _context.WorkItems.FindAsync(id);
            if (workItem == null)
            {
                return NotFound();
            }

            workItem.Description = workItemDTO.Description;
            workItem.Cost = workItemDTO.Cost;

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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkItemDTO>> PostWorkItem(WorkItemDTO workItemDTO)
        {
            var workItem = new WorkItem
            {
                Description = workItemDTO.Description,
                Cost = workItemDTO.Cost
            };

            _context.WorkItems.Add(workItem);
            await _context.SaveChangesAsync();

            workItemDTO.WorkItemID = workItem.WorkItemId;

            return CreatedAtAction(nameof(GetWorkItem), new { id = workItemDTO.WorkItemID }, workItemDTO);
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
            return _context.WorkItems.Any(e => e.WorkItemId == id);
        }
    }
}
