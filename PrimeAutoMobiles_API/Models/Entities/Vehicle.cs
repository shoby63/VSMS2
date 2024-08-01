using System.ComponentModel.DataAnnotations;

namespace PrimeAutoMobiles_API.Models.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(20)]
        public string LicensePlate { get; set; }

        public DateTime? LastServiceDate { get; set; }

        public Customer Customer { get; set; }
    }
}
