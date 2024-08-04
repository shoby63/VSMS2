namespace api.DTOS
{
    public class CustomerCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string ContactNumber { get; set; } = string.Empty;
    }
}
