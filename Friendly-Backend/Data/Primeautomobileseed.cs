using api.models;
using api.Data;
using api.DTOS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace api.Data
{
    public static class Seed
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = new PrimeAutomobilesDbContext(serviceProvider.GetRequiredService<DbContextOptions<PrimeAutomobilesDbContext>>());

            context.Database.EnsureCreated();

            // Seed data for other tables
            SeedCustomers(context);
            SeedVehicles(context);
            SeedServiceRepresentatives(context);
            SeedWorkItems(context);
            SeedServiceRecords(context);
            SeedBillOfMaterials(context);
            SeedInvoices(context);

            await context.SaveChangesAsync();
        }

        private static void SeedCustomers(PrimeAutomobilesDbContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer { Name = "John Doe", Address = "123 Main St", ContactNumber = "123-456-7890" },
                    new Customer { Name = "Jane Smith", Address = "456 Elm St", ContactNumber = "987-654-3210" }
                );
            }
        }

        private static void SeedVehicles(PrimeAutomobilesDbContext context)
        {
            if (!context.Vehicles.Any())
            {
                context.Vehicles.AddRange(
                    new Vehicle { Make = "Toyota", Model = "Camry", Year = 2020, CustomerID = 1 },
                    new Vehicle { Make = "Honda", Model = "Civic", Year = 2019, CustomerID = 2 }
                );
            }
        }

        private static void SeedServiceRepresentatives(PrimeAutomobilesDbContext context)
        {
            if (!context.ServiceRepresentatives.Any())
            {
                context.ServiceRepresentatives.AddRange(
                    new ServiceRepresentative { Name = "Alice Johnson", Email = "alice@example.com" },
                    new ServiceRepresentative { Name = "Bob Brown", Email = "bob@example.com" }
                );
            }
        }

        private static void SeedWorkItems(PrimeAutomobilesDbContext context)
        {
            if (!context.WorkItems.Any())
            {
                context.WorkItems.AddRange(
                    new WorkItem { Description = "Oil Change", Cost = 29.99m },
                    new WorkItem { Description = "Tire Rotation", Cost = 49.99m }
                );
            }
        }

        private static void SeedServiceRecords(PrimeAutomobilesDbContext context)
        {
            if (!context.ServiceRecords.Any())
            {
                context.ServiceRecords.AddRange(
                    new ServiceRecord { VehicleID = 1, ServiceRepresentativeID = 1, ServiceDate = DateTime.Now, Status = "Completed" },
                    new ServiceRecord { VehicleID = 2, ServiceRepresentativeID = 2, ServiceDate = DateTime.Now, Status = "Pending" }
                );
            }
        }

        private static void SeedBillOfMaterials(PrimeAutomobilesDbContext context)
        {
            if (!context.BillOfMaterials.Any())
            {
                context.BillOfMaterials.AddRange(
                    new BillOfMaterial { ServiceRecordID = 1, WorkItemID = 1, Quantity = 1 },
                    new BillOfMaterial { ServiceRecordID = 2, WorkItemID = 2, Quantity = 2 }
                );
            }
        }

        private static void SeedInvoices(PrimeAutomobilesDbContext context)
        {
            if (!context.Invoices.Any())
            {
                context.Invoices.AddRange(
                    new Invoice { ServiceRecordID = 1, InvoiceDate = DateTime.Now, TotalCost = 29.99m },
                    new Invoice { ServiceRecordID = 2, InvoiceDate = DateTime.Now, TotalCost  = 99.98m }
                );
            }
        }
    }
}
