using System.ComponentModel.DataAnnotations;

namespace AfroBeachApp.Models
{
    public class SystemInfo : AuditTrail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public byte[]? Logo { get; set; }
        public string? Address { get; set; }
        [Display(Name = "Telephone Number")]
        public string? TelephoneNumber { get; set; }
        [Display(Name = "Email Address")]
        public string? EmailAddress { get; set; }
        [Display(Name = "Service Hour")]
        public string? ServiceHour { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TikTokUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }

    }
}
