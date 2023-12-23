using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AfroBeachApp.Models
{
    public class Product : AuditTrail
    {
        [Key]
        public int Id { get;set; }
        [Display(Name = "Category")]
        public int ProductCategoryID { get; set; }
        [ForeignKey(nameof(ProductCategoryID))]
        public ProductCategory? ProductCategory { get; set;}

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
        public byte[]? Image1 { get; set; }
        public byte[]? Image2 { get; set; }
        public byte[]? Image3 { get; set; }
        public byte[]? Image4 { get; set; }

        [Display(Name = "Currency One")]
        public int? CurrencyOneID { get; set; }
        [ForeignKey(nameof(CurrencyOneID))]
        public Currency? CurrencyOne { get; set; }
        [Display(Name = "Currency One Price")]
        public decimal CurrencyOneAmount { get; set; }

        public int? CurrencyTwoID { get; set; }
        [ForeignKey(nameof(CurrencyTwoID))]
        public Currency? CurrencyTwo { get; set; }

        public decimal? CurrencyTwoAmount { get; set; }
    }
}
