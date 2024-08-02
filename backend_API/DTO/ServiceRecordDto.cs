namespace backend_API.DTO
{
    public class ServiceRecordDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int ServiceAdvisorId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Status { get; set; }  // Optional: Include a status field if needed
    }
}
