namespace backend_API.Model
{
    public class Vehicle
    {
        public int Id { get; set; }  // EF will handle the primary key generation
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required string LicensePlate { get; set; }
        public int? ServiceAdvisorId { get; set; }  // Nullable to allow unassigned vehicles
        public DateTime ServiceDueDate { get; set; }
        public ServiceAdvisor ServiceAdvisor { get; set; }
        // Foreign key
        public required int  CustomerId { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public ICollection<ServiceRecord> ServiceRecords { get; set; }
    }
}
