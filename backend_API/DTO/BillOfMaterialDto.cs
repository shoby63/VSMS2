namespace backend_API.DTO
{
    public class BillOfMaterialDto
    {
        public int Id { get; set; }
        public int ServiceRecordId { get; set; }
        public int WorkItemId { get; set; }
        public int Quantity { get; set; }
    }
}
