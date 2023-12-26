using System.ComponentModel.DataAnnotations;

namespace AfroBeachApp.Models
{
    public class OrderStatus : AuditTrail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
