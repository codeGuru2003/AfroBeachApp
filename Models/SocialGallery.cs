using System.ComponentModel.DataAnnotations;

namespace AfroBeachApp.Models
{
    public class SocialGallery
    {
        [Key]
        public int Id { get; set; }
        public byte[]? Image1 { get; set; }
        public byte[]? Image2 { get; set; }
        public byte[]? Image3 { get; set; }
        public byte[]? Image4 { get; set; }
        public byte[]? Image5 { get; set; }
        public byte[]? Image6 { get; set; }
    }
}
