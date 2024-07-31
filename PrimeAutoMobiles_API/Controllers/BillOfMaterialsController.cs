using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeAutoMobiles_API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrimeAutoMobiles_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace PrimeAutoMobiles_API.Controllers
{
    [Authorize(Policy = "AdminOrServiceAdvisor")]
    [Route("api/[controller]")]
    [ApiController]
    public class BillOfMaterialsController : ControllerBase
    {
        private readonly BillOfMaterialService _billOfMaterialService;

        public BillOfMaterialsController(BillOfMaterialService billOfMaterialService)
        {
            _billOfMaterialService = billOfMaterialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillOfMaterial>>> GetBillOfMaterials()
        {
            var billOfMaterials = await _billOfMaterialService.GetAllBillOfMaterialsAsync();
            return Ok(billOfMaterials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BillOfMaterial>> GetBillOfMaterial(int id)
        {
            var billOfMaterial = await _billOfMaterialService.GetBillOfMaterialByIdAsync(id);
            if (billOfMaterial == null)
            {
                return NotFound();
            }
            return Ok(billOfMaterial);
        }

        [HttpPost]
        public async Task<ActionResult<BillOfMaterial>> PostBillOfMaterial(BillOfMaterial billOfMaterial)
        {
            await _billOfMaterialService.AddBillOfMaterialAsync(billOfMaterial);
            return CreatedAtAction(nameof(GetBillOfMaterial), new { id = billOfMaterial.BOMId }, billOfMaterial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillOfMaterial(int id, BillOfMaterial billOfMaterial)
        {
            if (id != billOfMaterial.BOMId)
            {
                return BadRequest();
            }
            await _billOfMaterialService.UpdateBillOfMaterialAsync(billOfMaterial);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillOfMaterial(int id)
        {
            await _billOfMaterialService.DeleteBillOfMaterialAsync(id);
            return NoContent();
        }
    }
}
