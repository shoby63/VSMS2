using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.models;
using api.DTOS;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillOfMaterialsController : ControllerBase
    {
        private readonly PrimeAutomobilesDbContext _context;

        public BillOfMaterialsController(PrimeAutomobilesDbContext context)
        {
            _context = context;
        }

        // GET: api/BillOfMaterials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillOfMaterialDTO>>> GetBillOfMaterials()
        {
            return await _context.BillOfMaterials
                .Select(b => new BillOfMaterialDTO
                {
                    BillOfMaterialID = b.BillOfMaterialID,
                    ServiceRecordID = b.ServiceRecordID,
                    WorkItemID = b.WorkItemID,
                    Quantity = b.Quantity
                }).ToListAsync();
        }

        // GET: api/BillOfMaterials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillOfMaterialDTO>> GetBillOfMaterial(int id)
        {
            var billOfMaterial = await _context.BillOfMaterials.FindAsync(id);

            if (billOfMaterial == null)
            {
                return NotFound();
            }

            var billOfMaterialDTO = new BillOfMaterialDTO
            {
                BillOfMaterialID = billOfMaterial.BillOfMaterialID,
                ServiceRecordID = billOfMaterial.ServiceRecordID,
                WorkItemID = billOfMaterial.WorkItemID,
                Quantity = billOfMaterial.Quantity
            };

            return billOfMaterialDTO;
        }

        // PUT: api/BillOfMaterials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillOfMaterial(int id, BillOfMaterialDTO billOfMaterialDTO)
        {
            if (id != billOfMaterialDTO.BillOfMaterialID)
            {
                return BadRequest();
            }

            // Check if the related entities exist
            var serviceRecordExists = await _context.ServiceRecords.AnyAsync(sr => sr.ServiceRecordId == billOfMaterialDTO.ServiceRecordID);
            var workItemExists = await _context.WorkItems.AnyAsync(wi => wi.WorkItemId == billOfMaterialDTO.WorkItemID);

            if (!serviceRecordExists || !workItemExists)
            {
                return BadRequest("Invalid foreign key values.");
            }

            var billOfMaterial = await _context.BillOfMaterials.FindAsync(id);

            if (billOfMaterial == null)
            {
                return NotFound();
            }

            billOfMaterial.ServiceRecordID = billOfMaterialDTO.ServiceRecordID;
            billOfMaterial.WorkItemID = billOfMaterialDTO.WorkItemID;
            billOfMaterial.Quantity = billOfMaterialDTO.Quantity;

            _context.Entry(billOfMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)

            {
                if (!BillOfMaterialExists(id))
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


        // POST: api/BillOfMaterials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillOfMaterialDTO>> PostBillOfMaterial(BillOfMaterialDTO billOfMaterialDTO)
        {
            // Check if the related entities exist
            var serviceRecordExists = await _context.ServiceRecords.AnyAsync(sr => sr.ServiceRecordId == billOfMaterialDTO.ServiceRecordID);
            var workItemExists = await _context.WorkItems.AnyAsync(wi => wi.WorkItemId == billOfMaterialDTO.WorkItemID);

            if (!serviceRecordExists || !workItemExists)
            {
                return BadRequest("Invalid foreign key values.");
            }

            var billOfMaterial = new BillOfMaterial
            {
                ServiceRecordID = billOfMaterialDTO.ServiceRecordID,
                WorkItemID = billOfMaterialDTO.WorkItemID,
                Quantity = billOfMaterialDTO.Quantity
            };

            _context.BillOfMaterials.Add(billOfMaterial);
            await _context.SaveChangesAsync();

            billOfMaterialDTO.BillOfMaterialID = billOfMaterial.BillOfMaterialID;

            return CreatedAtAction(nameof(GetBillOfMaterial), new { id = billOfMaterialDTO.BillOfMaterialID }, billOfMaterialDTO);
        }


        // DELETE: api/BillOfMaterials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillOfMaterial(int id)
        {
            var billOfMaterial = await _context.BillOfMaterials.FindAsync(id);
            if (billOfMaterial == null)
            {
                return NotFound();
            }

            _context.BillOfMaterials.Remove(billOfMaterial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillOfMaterialExists(int id)
        {
            return _context.BillOfMaterials.Any(e => e.BillOfMaterialID == id);
        }
    }
}
