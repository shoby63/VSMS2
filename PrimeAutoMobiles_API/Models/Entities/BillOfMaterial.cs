using System.ComponentModel.DataAnnotations;

namespace PrimeAutoMobiles_API.Models.Entities
{
    public class BillOfMaterial
    {
        [Key]
        public int BOMId { get; set; }

        [Required]
        public int ServiceRecordId { get; set; }

        [Required]
        public int WorkItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public ServiceRecord ServiceRecord { get; set; }
        public WorkItem WorkItem { get; set; }
    }
}
