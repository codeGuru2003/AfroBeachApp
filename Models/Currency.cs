using System.ComponentModel.DataAnnotations;

namespace AfroBeachApp.Models
{
    public class Currency : AuditTrail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; } = string.Empty;
        public decimal ExchangeRate { get; set; }
    }
}
