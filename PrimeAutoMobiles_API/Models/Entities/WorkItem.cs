using System.ComponentModel.DataAnnotations;

namespace PrimeAutoMobiles_API.Models.Entities
{
    public class WorkItem
    {
        public int WorkItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal StandardCost { get; set; }
    }
}
