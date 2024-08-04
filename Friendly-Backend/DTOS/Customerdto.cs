namespace api.DTOS
{
    public class Customerdto
    {
        public int CustomerID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string ContactNumber { get; set; } = string.Empty;
    }
}
