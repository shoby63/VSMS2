using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class VehicleController : ControllerBase
    {
        private readonly PrimeAutomobilesDbContext _context;

        public VehicleController(PrimeAutomobilesDbContext context)
        {
            _context = context;
        }

        // GET: api/Vehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDTO>>> GetVehicles()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            var vehicleDTOs = vehicles.Select(v => new VehicleDTO
            {
                VehicleID = v.VehicleId,
                Make = v.Make,
                Model = v.Model,
                Year = v.Year,
                CustomerID = v.CustomerID
            }).ToList();

            return Ok(vehicleDTOs);
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDTO>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleDTO = new VehicleDTO
            {
                VehicleID = vehicle.VehicleId,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                CustomerID = vehicle.CustomerID
            };

            return Ok(vehicleDTO);
        }

        // POST: api/Vehicle
        [HttpPost]
        public async Task<ActionResult<VehicleDTO>> CreateVehicle(VehicleCreateDTO vehicleCreateDTO)
        {
            // Check if the CustomerID exists
            var customerExists = await _context.Customers.AnyAsync(c => c.CustomerId == vehicleCreateDTO.CustomerID);
            if (!customerExists)
            {
                return BadRequest("Invalid CustomerID. The specified customer does not exist.");
            }

            var vehicle = new Vehicle
            {
                Make = vehicleCreateDTO.Make,
                Model = vehicleCreateDTO.Model,
                Year = vehicleCreateDTO.Year,
                CustomerID = vehicleCreateDTO.CustomerID
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            var vehicleDTO = new VehicleDTO
            {
                VehicleID = vehicle.VehicleId,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                CustomerID = vehicle.CustomerID
            };

            return CreatedAtAction(nameof(GetVehicle), new { id = vehicleDTO.VehicleID }, vehicleDTO);
        }

        // PUT: api/Vehicle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, VehicleDTO vehicleDTO)
        {
            if (id != vehicleDTO.VehicleID)
            {
                return BadRequest();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            vehicle.Make = vehicleDTO.Make;
            vehicle.Model = vehicleDTO.Model;
            vehicle.Year = vehicleDTO.Year;
            vehicle.CustomerID = vehicleDTO.CustomerID;

            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
