using backend_API.Data;
using backend_API.Model;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

  /*  // GET: api/Admin/DueVehicles
    [HttpGet("DueVehicles")]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetDueVehicles()
    {
        // Implement your logic to determine which vehicles are due
        var dueVehicles = await _context.Vehicles
                                        .Where(v => *//* your due logic here *//*)
                                        .Include(v => v.Customer)
                                        .Include(v => v.ServiceAdvisor)
                                        .ToListAsync();
        return Ok(dueVehicles);
    }*/

    // POST: api/Admin/AssignServiceAdvisor
    [HttpPost("AssignServiceAdvisor")]
    public async Task<IActionResult> AssignServiceAdvisor(int vehicleId, int serviceAdvisorId)
    {
        var vehicle = await _context.Vehicles.FindAsync(vehicleId);
        if (vehicle == null)
        {
            return NotFound("Vehicle not found.");
        }

        vehicle.ServiceAdvisorId = serviceAdvisorId;
        await _context.SaveChangesAsync();

        return Ok("Service advisor assigned successfully.");
    }
}
