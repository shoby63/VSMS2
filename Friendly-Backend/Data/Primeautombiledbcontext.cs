using Microsoft.EntityFrameworkCore;
using api.models;

namespace api.Data
{
    public class PrimeAutomobilesDbContext : DbContext
    {
        public PrimeAutomobilesDbContext(DbContextOptions<PrimeAutomobilesDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ServiceRepresentative> ServiceRepresentatives { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }
        public DbSet<BillOfMaterial> BillOfMaterials { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.CustomerId).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.ContactNumber).IsRequired();
            });

            modelBuilder.Entity<BillOfMaterial>(entity =>
            {
                
                entity.HasKey(b => b.BillOfMaterialID);

               
                entity.HasOne(b => b.ServiceRecord)
                    .WithMany(s => s.BillOfMaterials)
                    .HasForeignKey(b => b.ServiceRecordID);

                entity.HasOne(b => b.WorkItem)
                    .WithMany(w => w.BillOfMaterials)
                    .HasForeignKey(b => b.WorkItemID);
            });


            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasOne(v => v.Customer)
                    .WithMany(c => c.Vehicles)
                    .HasForeignKey(v => v.CustomerID);
            });

            modelBuilder.Entity<ServiceRecord>(entity =>
            {
                entity.HasOne(s => s.Vehicle)
                    .WithMany(v => v.ServiceRecords)
                    .HasForeignKey(s => s.VehicleID);
                entity.HasOne(s => s.ServiceRepresentative)
                    .WithMany(sr => sr.ServiceRecords)
                    .HasForeignKey(s => s.ServiceRepresentativeID);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasOne(i => i.ServiceRecord)
                    .WithOne(s => s.Invoice)
                    .HasForeignKey<Invoice>(i => i.ServiceRecordID);
            });
        }
    }
}
