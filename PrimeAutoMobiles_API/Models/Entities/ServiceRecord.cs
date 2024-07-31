using System.ComponentModel.DataAnnotations;

namespace PrimeAutoMobiles_API.Models.Entities
{
    public class ServiceRecord
    {
        public int ServiceRecordId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int ServiceAdvisorId { get; set; }

        [Required]
        public DateTime ServiceDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        public Vehicle Vehicle { get; set; }
        public ServiceAdvisor ServiceAdvisor { get; set; }
    }

}
