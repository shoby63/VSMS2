using System.ComponentModel.DataAnnotations;

namespace PrimeAutoMobiles_API.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; } 

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }

        public int? ServiceAdvisorId { get; set; }
        public ServiceAdvisor ServiceAdvisor { get; set; }
    }
}
