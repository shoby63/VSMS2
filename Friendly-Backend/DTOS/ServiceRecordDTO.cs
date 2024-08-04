namespace api.DTOS
{
    public class ServiceRecordDTO
    {
        public int ServiceRecordId { get; set; }
        public DateTime ServiceDate { get; set; }
        public int VehicleID { get; set; }
        public int ServiceRepresentativeID { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
