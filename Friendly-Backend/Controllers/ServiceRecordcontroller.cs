using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Add this line
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using api.DTOS;
using api.Data;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRecordController : ControllerBase
    {
        private readonly PrimeAutomobilesDbContext _context;

        public ServiceRecordController(PrimeAutomobilesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRecordDTO>>> GetServiceRecords()
        {
            var serviceRecords = await _context.ServiceRecords.ToListAsync();

            var serviceRecordDTOs = serviceRecords.Select(sr => new ServiceRecordDTO
            {
                ServiceRecordId = sr.ServiceRecordId,
                ServiceDate = sr.ServiceDate,
                VehicleID = sr.VehicleID,
                ServiceRepresentativeID = sr.ServiceRepresentativeID,
                Status = sr.Status
            }).ToList();

            return Ok(serviceRecordDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRecordDTO>> GetServiceRecord(int id)
        {
            var serviceRecord = await _context.ServiceRecords.FindAsync(id);

            if (serviceRecord == null)
            {
                return NotFound();
            }

            var serviceRecordDTO = new ServiceRecordDTO
            {
                ServiceRecordId = serviceRecord.ServiceRecordId,
                ServiceDate = serviceRecord.ServiceDate,
                VehicleID = serviceRecord.VehicleID,
                ServiceRepresentativeID = serviceRecord.ServiceRepresentativeID,
                Status = serviceRecord.Status
            };

            return Ok(serviceRecordDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceRecordDTO>> CreateServiceRecord(ServiceRecordDTO serviceRecordDTO)
        {
            // Check if the Vehicle exists
            var vehicleExists = await _context.Vehicles.AnyAsync(v => v.VehicleId == serviceRecordDTO.VehicleID);
            if (!vehicleExists)
            {
                return BadRequest("Invalid VehicleID.");
            }

            // C   heck if the Service Representative exists
            var representativeExists = await _context.ServiceRepresentatives.AnyAsync(sr => sr.ServiceRepresentativeId == serviceRecordDTO.ServiceRepresentativeID);
            if (!representativeExists)
            {
                return BadRequest("Invalid ServiceRepresentativeID.");
            }

            var serviceRecord = new ServiceRecord
            {
                ServiceDate = serviceRecordDTO.ServiceDate,
                VehicleID = serviceRecordDTO.VehicleID,
                ServiceRepresentativeID = serviceRecordDTO.ServiceRepresentativeID,
                Status = serviceRecordDTO.Status
            };

            _context.ServiceRecords.Add(serviceRecord);
            await _context.SaveChangesAsync();

            serviceRecordDTO.ServiceRecordId = serviceRecord.ServiceRecordId;

            return CreatedAtAction(nameof(GetServiceRecord), new { id = serviceRecordDTO.ServiceRecordId }, serviceRecordDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServiceRecord(int id, ServiceRecordDTO serviceRecordDTO)
        {
            // Check if the ID in the URL matches the ID in the payload
            if (id != serviceRecordDTO.ServiceRecordId)
            {
                return BadRequest(new { message = "Mismatched ID in URL and payload." });
            }

            // Find the existing service record
            var serviceRecord = await _context.ServiceRecords.FindAsync(id);

            // Check if the service record exists
            if (serviceRecord == null)
            {
                return NotFound(new { message = "Service record not found." });
            }

            // Validate Vehicle and ServiceRepresentative existence
            var vehicleExists = await _context.Vehicles.AnyAsync(v => v.VehicleId == serviceRecordDTO.VehicleID);
            if (!vehicleExists)
            {
                return BadRequest(new { message = "Invalid VehicleID." });
            }

            var representativeExists = await _context.ServiceRepresentatives.AnyAsync(sr => sr.ServiceRepresentativeId == serviceRecordDTO.ServiceRepresentativeID);
            if (!representativeExists)
            {
                return BadRequest(new { message = "Invalid ServiceRepresentativeID." });
            }

            // Update the service record
            serviceRecord.ServiceDate = serviceRecordDTO.ServiceDate;
            serviceRecord.VehicleID = serviceRecordDTO.VehicleID;
            serviceRecord.ServiceRepresentativeID = serviceRecordDTO.ServiceRepresentativeID;
            serviceRecord.Status = serviceRecordDTO.Status;

            // Save changes to the database
            try
            {
                _context.ServiceRecords.Update(serviceRecord);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Conflict(new { message = "Concurrency issue while updating the record.", details = ex.Message });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { message = "Database update issue.", details = ex.Message });
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceRecord(int id)
        {
            var serviceRecord = await _context.ServiceRecords.FindAsync(id);

            if (serviceRecord == null)
            {
                return NotFound();
            }

            _context.ServiceRecords.Remove(serviceRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
