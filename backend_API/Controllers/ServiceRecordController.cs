using backend_API.Data;
using backend_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class ServiceRecordsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ServiceRecordsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("due")]
    public async Task<IActionResult> GetDueVehicles()
    {
        var dueVehicles = await _context.Vehicles
            .Where(v => v.ServiceDueDate <= DateTime.Now &&
                        !v.ServiceRecords.Any(sr => sr.ServiceDate > DateTime.Now))
            .ToListAsync();

        return Ok(dueVehicles);
    }

    [HttpGet("under-service")]
    public async Task<IActionResult> GetVehiclesUnderService()
    {
        var vehiclesUnderService = await _context.ServiceRecords
            .Include(sr => sr.Vehicle)
            .Include(sr => sr.ServiceAdvisor)
            .Where(sr => sr.Status != "Completed") // Assuming status "Completed" means service is finished
            .Select(sr => new
            {
                sr.Id,
                Vehicle = sr.Vehicle,
                ServiceAdvisor = sr.ServiceAdvisor,
                sr.ServiceDate,
                sr.Status
            })
            .ToListAsync();

        return Ok(vehiclesUnderService);
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetServiceDetails(int id)
    {
        var serviceRecord = await _context.ServiceRecords
            .Include(sr => sr.Vehicle)
            .Include(sr => sr.ServiceAdvisor)
            .Where(sr => sr.Id == id)
            .FirstOrDefaultAsync();

        if (serviceRecord == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            serviceRecord.Id,
            Vehicle = serviceRecord.Vehicle,
            ServiceAdvisor = serviceRecord.ServiceAdvisor,
            serviceRecord.ServiceDate,
            serviceRecord.Status
        });
    }

    [HttpPut("update-status/{id}")]
    public async Task<IActionResult> UpdateServiceStatus(int id, [FromBody] UpdateServiceStatusRequest request)
    {
        var serviceRecord = await _context.ServiceRecords.FindAsync(id);
        if (serviceRecord == null)
        {
            return NotFound();
        }

        serviceRecord.Status = request.Status;
        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpPost("assign")]
    public async Task<IActionResult> AssignServiceAdvisor([FromBody] AssignServiceAdvisorRequest request)
    {
        var serviceRecord = new ServiceRecord
        {
            VehicleId = request.VehicleId,
            ServiceAdvisorId = request.ServiceAdvisorId,
            ServiceDate = DateTime.Now
        };

        _context.ServiceRecords.Add(serviceRecord);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("serviced")]
    public async Task<IActionResult> GetServicedVehicles()
    {
        var servicedVehicles = await _context.ServiceRecords
            .Include(sr => sr.Vehicle)
            .Include(sr => sr.ServiceAdvisor)
            .Where(sr => sr.Status == "Completed" && !sr.IsDispatched)
            .Select(sr => new
            {
                sr.Id,
                Vehicle = sr.Vehicle,
                ServiceAdvisor = sr.ServiceAdvisor,
                sr.ServiceDate,
                sr.Status
            })
            .ToListAsync();

        return Ok(servicedVehicles);
    }

    [HttpPut("dispatch/{id}")]
    public async Task<IActionResult> DispatchVehicle(int id)
    {
        var serviceRecord = await _context.ServiceRecords.FindAsync(id);
        if (serviceRecord == null)
        {
            return NotFound();
        }

        if (serviceRecord.Status != "Completed")
        {
            return BadRequest("Service record is not completed yet.");
        }

        serviceRecord.IsDispatched = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Endpoint to get scheduled services for a specific advisor
    [HttpGet("scheduled/{advisorId}")]
    public async Task<IActionResult> GetScheduledServices(int advisorId)
    {
        var scheduledServices = await _context.ServiceRecords
            .Include(sr => sr.Vehicle)
            .Include(sr => sr.BillOfMaterials) // Include BillOfMaterials
            .Where(sr => sr.ServiceAdvisorId == advisorId && sr.Status == "Scheduled")
            .Select(sr => new
            {
                sr.Id,
                Vehicle = sr.Vehicle,
                sr.ServiceDate,
                BillOfMaterials = sr.BillOfMaterials.Select(bom => new
                {
                    bom.Id,
                    bom.WorkItemId,
                    bom.Quantity,
                    WorkItem = bom.WorkItem // Include WorkItem details if needed
                }).ToList()
            })
            .ToListAsync();

        return Ok(scheduledServices);
    }


  

    // Endpoint to update the Bill of Materials
    [HttpPut("update-bom/{id}")]
    public async Task<IActionResult> UpdateBillOfMaterials(int id, [FromBody] UpdateBillOfMaterialsRequest request)
    {
        var serviceRecord = await _context.ServiceRecords
            .Include(sr => sr.BillOfMaterials) // Ensure BillOfMaterials are loaded
            .FirstOrDefaultAsync(sr => sr.Id == id);

        if (serviceRecord == null)
        {
            return NotFound();
        }

        if (serviceRecord.IsCompleted)
        {
            return BadRequest("Service has already been completed.");
        }

        // Remove existing BillOfMaterials
        _context.BillOfMaterials.RemoveRange(serviceRecord.BillOfMaterials);

        // Add new BillOfMaterials
        foreach (var bom in request.BillOfMaterials)
        {
            _context.BillOfMaterials.Add(new BillOfMaterial
            {
                ServiceRecordId = id,
                WorkItemId = bom.WorkItemId,
                Quantity = bom.Quantity
            });
        }

        await _context.SaveChangesAsync();

        return NoContent();
    }
    // Endpoint to mark the service as completed
    [HttpPut("complete/{id}")]
    public async Task<IActionResult> CompleteService(int id)
    {
        var serviceRecord = await _context.ServiceRecords.FindAsync(id);
        if (serviceRecord == null)
        {
            return NotFound();
        }

        if (serviceRecord.IsCompleted)
        {
            return BadRequest("Service is already completed.");
        }

        serviceRecord.IsCompleted = true;
        serviceRecord.Status = "Completed";
        await _context.SaveChangesAsync();

        return NoContent();
    }
}





public class AssignServiceAdvisorRequest
{
    public int VehicleId { get; set; }
    public int ServiceAdvisorId { get; set; }
}
public class UpdateServiceStatusRequest
{
    public string Status { get; set; }
}

public class UpdateBillOfMaterialsRequest
{
    public List<BillOfMaterialDto> BillOfMaterials { get; set; }
}

public class BillOfMaterialDto
{
    public int WorkItemId { get; set; }
    public int Quantity { get; set; }
}