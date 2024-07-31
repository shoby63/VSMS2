using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

using PrimeAutoMobiles_API.Data;
using PrimeAutoMobiles_API.Models.Entities;

namespace PrimeAutoMobiles_API.Services
{
    public class ServiceAdvisorService
    {
        private readonly ApplicationDbContext _context;

        public ServiceAdvisorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceAdvisor>> GetAllServiceAdvisorsAsync()
        {
            return await _context.ServiceAdvisors.ToListAsync();
        }

        public async Task<ServiceAdvisor> GetServiceAdvisorByIdAsync(int id)
        {
            return await _context.ServiceAdvisors.FindAsync(id);
        }

        public async Task AddServiceAdvisorAsync(ServiceAdvisor serviceAdvisor)
        {
            _context.ServiceAdvisors.Add(serviceAdvisor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAdvisorAsync(ServiceAdvisor serviceAdvisor)
        {
            _context.Entry(serviceAdvisor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAdvisorAsync(int id)
        {
            var serviceAdvisor = await _context.ServiceAdvisors.FindAsync(id);
            if (serviceAdvisor != null)
            {
                _context.ServiceAdvisors.Remove(serviceAdvisor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
