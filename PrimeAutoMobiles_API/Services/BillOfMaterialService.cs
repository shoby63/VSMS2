using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrimeAutoMobiles_API.Data;
using PrimeAutoMobiles_API.Models.Entities;

namespace PrimeAutoMobiles_API.Services
{
    public class BillOfMaterialService
    {
        private readonly ApplicationDbContext _context;

        public BillOfMaterialService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BillOfMaterial>> GetAllBillOfMaterialsAsync()
        {
            return await _context.BillOfMaterials.ToListAsync();
        }

        public async Task<BillOfMaterial> GetBillOfMaterialByIdAsync(int id)
        {
            return await _context.BillOfMaterials.FindAsync(id);
        }

        public async Task AddBillOfMaterialAsync(BillOfMaterial billOfMaterial)
        {
            _context.BillOfMaterials.Add(billOfMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBillOfMaterialAsync(BillOfMaterial billOfMaterial)
        {
            _context.Entry(billOfMaterial).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBillOfMaterialAsync(int id)
        {
            var billOfMaterial = await _context.BillOfMaterials.FindAsync(id);
            if (billOfMaterial != null)
            {
                _context.BillOfMaterials.Remove(billOfMaterial);
                await _context.SaveChangesAsync();
            }
        }
    }
}
