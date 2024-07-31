using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrimeAutoMobiles_API.Data;
using PrimeAutoMobiles_API.Models.Entities;

namespace PrimeAutoMobiles_API.Services
{
    public class WorkItemService
    {
        private readonly ApplicationDbContext _context;

        public WorkItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkItem>> GetAllWorkItemsAsync()
        {
            return await _context.WorkItems.ToListAsync();
        }

        public async Task<WorkItem> GetWorkItemByIdAsync(int id)
        {
            return await _context.WorkItems.FindAsync(id);
        }

        public async Task AddWorkItemAsync(WorkItem workItem)
        {
            _context.WorkItems.Add(workItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWorkItemAsync(WorkItem workItem)
        {
            _context.Entry(workItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWorkItemAsync(int id)
        {
            var workItem = await _context.WorkItems.FindAsync(id);
            if (workItem != null)
            {
                _context.WorkItems.Remove(workItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
