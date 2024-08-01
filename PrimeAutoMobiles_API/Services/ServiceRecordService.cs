using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrimeAutoMobiles_API.Data;
using PrimeAutoMobiles_API.Models.Entities;

namespace PrimeAutoMobiles_API.Services
{
    public class ServiceRecordService
    {
        private readonly ApplicationDbContext _context;

        public ServiceRecordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceRecord>> GetAllServiceRecordsAsync()
        {
            return await _context.ServiceRecords.ToListAsync();
        }

        public async Task<ServiceRecord> GetServiceRecordByIdAsync(int id)
        {
            return await _context.ServiceRecords.FindAsync(id);
        }

        public async Task AddServiceRecordAsync(ServiceRecord serviceRecord)
        {
            _context.ServiceRecords.Add(serviceRecord);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceRecordAsync(ServiceRecord serviceRecord)
        {
            _context.Entry(serviceRecord).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceRecordAsync(int id)
        {
            var serviceRecord = await _context.ServiceRecords.FindAsync(id);
            if (serviceRecord != null)
            {
                _context.ServiceRecords.Remove(serviceRecord);
                await _context.SaveChangesAsync();
            }
        }
    }
}
