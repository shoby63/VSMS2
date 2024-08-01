using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrimeAutoMobiles_API.Models.Entities;
using PrimeAutoMobiles_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace PrimeAutoMobiles_API.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAdvisorsController : ControllerBase
    {
        private readonly ServiceAdvisorService _serviceAdvisorService;

        public ServiceAdvisorsController(ServiceAdvisorService serviceAdvisorService)
        {
            _serviceAdvisorService = serviceAdvisorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceAdvisor>>> GetServiceAdvisors()
        {
            var serviceAdvisors = await _serviceAdvisorService.GetAllServiceAdvisorsAsync();
            return Ok(serviceAdvisors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceAdvisor>> GetServiceAdvisor(int id)
        {
            var serviceAdvisor = await _serviceAdvisorService.GetServiceAdvisorByIdAsync(id);
            if (serviceAdvisor == null)
            {
                return NotFound();
            }
            return Ok(serviceAdvisor);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceAdvisor>> PostServiceAdvisor(ServiceAdvisor serviceAdvisor)
        {
            await _serviceAdvisorService.AddServiceAdvisorAsync(serviceAdvisor);
            return CreatedAtAction(nameof(GetServiceAdvisor), new { id = serviceAdvisor.ServiceAdvisorId }, serviceAdvisor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceAdvisor(int id, ServiceAdvisor serviceAdvisor)
        {
            if (id != serviceAdvisor.ServiceAdvisorId)
            {
                return BadRequest();
            }
            await _serviceAdvisorService.UpdateServiceAdvisorAsync(serviceAdvisor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceAdvisor(int id)
        {
            await _serviceAdvisorService.DeleteServiceAdvisorAsync(id);
            return NoContent();
        }
    }
}
