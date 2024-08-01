namespace backend_API.Model
{
    public class BillOfMaterial
    {
        public int Id { get; set; }  // EF will handle the primary key generation
        public required int ServiceRecordId { get; set; }
        public required int WorkItemId { get; set; }
        public  required int Quantity { get; set; }

        // Navigation properties
        public ServiceRecord ServiceRecord { get; set; }
        public WorkItem WorkItem { get; set; }
    }
}
