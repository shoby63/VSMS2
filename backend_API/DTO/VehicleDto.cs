namespace backend_API.DTO
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int CustomerId { get; set; }  // Optional: Include related data if needed
    }
}
