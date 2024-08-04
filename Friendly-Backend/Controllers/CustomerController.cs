using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.models;
using api.DTOS;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly PrimeAutomobilesDbContext _context;

        public CustomersController(PrimeAutomobilesDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customerdto>>> GetCustomers()
        {
            return await _context.Customers
                .Select(c => new Customerdto
                {
                    CustomerID = c.CustomerId,
                    Name = c.Name,
                    Address = c.Address,
                    ContactNumber = c.ContactNumber
                })
                .ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customerdto>> GetCustomer(int id)
        {
            var customer = await _context.Customers
                .Select(c => new Customerdto
                {
                    CustomerID = c.CustomerId,
                    Name = c.Name,
                    Address = c.Address,
                    ContactNumber = c.ContactNumber
                })
                .FirstOrDefaultAsync(c => c.CustomerID == id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customerdto customerDto)
        {
            if (id != customerDto.CustomerID)
            {
                return BadRequest();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = customerDto.Name;
            customer.Address = customerDto.Address;
            customer.ContactNumber = customerDto.ContactNumber;

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customerdto>> PostCustomer(CustomerCreateDTO customerCreateDto)
        {
            var customer = new Customer
            {
                Name = customerCreateDto.Name,
                Address = customerCreateDto.Address,
                ContactNumber = customerCreateDto.ContactNumber
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            var customerDto = new Customerdto
            {
                CustomerID = customer.CustomerId,
                Name = customer.Name,
                Address = customer.Address,
                ContactNumber = customer.ContactNumber
            };

            return CreatedAtAction(nameof(GetCustomer), new { id = customerDto.CustomerID }, customerDto);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
