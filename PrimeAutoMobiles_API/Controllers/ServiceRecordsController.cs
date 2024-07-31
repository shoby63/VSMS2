using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeAutoMobiles_API.Models.Entities;
using PrimeAutoMobiles_API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeAutoMobiles_API.Controllers
{
    [Authorize(Policy = "AdminOrServiceAdvisor")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRecordsController : ControllerBase
    {
        private readonly ServiceRecordService _serviceRecordService;

        public ServiceRecordsController(ServiceRecordService serviceRecordService)
        {
            _serviceRecordService = serviceRecordService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRecord>>> GetServiceRecords()
        {
            var serviceRecords = await _serviceRecordService.GetAllServiceRecordsAsync();
            return Ok(serviceRecords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRecord>> GetServiceRecord(int id)
        {
            var serviceRecord = await _serviceRecordService.GetServiceRecordByIdAsync(id);
            if (serviceRecord == null)
            {
                return NotFound();
            }
            return Ok(serviceRecord);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceRecord>> PostServiceRecord(ServiceRecord serviceRecord)
        {
            await _serviceRecordService.AddServiceRecordAsync(serviceRecord);
            return CreatedAtAction(nameof(GetServiceRecord), new { id = serviceRecord.ServiceRecordId }, serviceRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceRecord(int id, ServiceRecord serviceRecord)
        {
            if (id != serviceRecord.ServiceRecordId)
            {
                return BadRequest();
            }
            await _serviceRecordService.UpdateServiceRecordAsync(serviceRecord);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceRecord(int id)
        {
            await _serviceRecordService.DeleteServiceRecordAsync(id);
            return NoContent();
        }
    }
}
