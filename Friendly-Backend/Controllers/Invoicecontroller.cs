using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.models;
using api.DTOS;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly PrimeAutomobilesDbContext _context;

        public InvoicesController(PrimeAutomobilesDbContext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetInvoices()
        {
            return await _context.Invoices
                .Select(i => new InvoiceDTO
                {
                    InvoiceID = i.InvoiceId,
                    ServiceRecordID = i.ServiceRecordID,
                    InvoiceDate = i.InvoiceDate,
                    TotalCost = i.TotalCost
                }).ToListAsync();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDTO>> GetInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            var invoiceDTO = new InvoiceDTO
            {
                InvoiceID = invoice.InvoiceId,
                ServiceRecordID = invoice.ServiceRecordID,
                InvoiceDate = invoice.InvoiceDate,
                TotalCost = invoice.TotalCost
            };

            return invoiceDTO;
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, InvoiceDTO invoiceDTO)
        {
            if (id != invoiceDTO.InvoiceID)
            {
                return BadRequest();
            }

            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            invoice.ServiceRecordID = invoiceDTO.ServiceRecordID;
            invoice.InvoiceDate = invoiceDTO.InvoiceDate;
            invoice.TotalCost = invoiceDTO.TotalCost;

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
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
        */
       /* // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceDTO>> PostInvoice(InvoiceDTO invoiceDTO)
        {
            var invoice = new Invoice
            {
                ServiceRecordID = invoiceDTO.ServiceRecordID,
                InvoiceDate = invoiceDTO.InvoiceDate,
                TotalCost = invoiceDTO.TotalCost
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            invoiceDTO.InvoiceID = invoice.InvoiceId;

            return CreatedAtAction(nameof(GetInvoice), new { id = invoiceDTO.InvoiceID }, invoiceDTO);
        }

        */
        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.InvoiceId == id);
        }
    }
}
