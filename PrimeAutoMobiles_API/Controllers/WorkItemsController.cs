using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeAutoMobiles_API.Models.Entities;
using PrimeAutoMobiles_API.Services;

namespace PrimeAutoMobiles_API.Controllers
{
    [Authorize(Policy = "AdminOrServiceAdvisor")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemsController : ControllerBase
    {
        private readonly WorkItemService _workItemService;

        public WorkItemsController(WorkItemService workItemService)
        {
            _workItemService = workItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkItem>>> GetWorkItems()
        {
            var workItems = await _workItemService.GetAllWorkItemsAsync();
            return Ok(workItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkItem>> GetWorkItem(int id)
        {
            var workItem = await _workItemService.GetWorkItemByIdAsync(id);
            if (workItem == null)
            {
                return NotFound();
            }
            return Ok(workItem);
        }

        [HttpPost]
        public async Task<ActionResult<WorkItem>> PostWorkItem(WorkItem workItem)
        {
            await _workItemService.AddWorkItemAsync(workItem);
            return CreatedAtAction(nameof(GetWorkItem), new { id = workItem.WorkItemId }, workItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkItem(int id, WorkItem workItem)
        {
            if (id != workItem.WorkItemId)
            {
                return BadRequest();
            }
            await _workItemService.UpdateWorkItemAsync(workItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkItem(int id)
        {
            await _workItemService.DeleteWorkItemAsync(id);
            return NoContent();
        }
    }
}
