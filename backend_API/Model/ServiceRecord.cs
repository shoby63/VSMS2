namespace backend_API.Model
{
    public class ServiceRecord
    {
        public int Id { get; set; }  // EF will handle the primary key generation
        public required  int VehicleId { get; set; }
        public required int ServiceAdvisorId { get; set; }
        public required DateTime ServiceDate { get; set; }
        public string Status { get; set; } // New property to track service status
        public bool IsDispatched { get; set; } //  property to track dispatch status
       // public string BillOfMaterials { get; set; } // To store the bill of materials
        public bool IsCompleted { get; set; } // To track if the service is completed

        // Navigation properties
        public Vehicle Vehicle { get; set; }
        public ServiceAdvisor ServiceAdvisor { get; set; }
        public ICollection<BillOfMaterial> BillOfMaterials { get; set; }
    }
}
