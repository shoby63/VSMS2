namespace api.DTOS
{
    public class VehicleDTO
    {
        public int VehicleID { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public int CustomerID { get; set; }
    }
}
