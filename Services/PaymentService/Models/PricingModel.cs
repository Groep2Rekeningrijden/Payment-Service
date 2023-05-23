using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentService.Models
{
    public class PricingModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string PriceTitle { get; set; }

        [Required]
        public string PriceType { get; set; }

        [Required]
        public int ValueName { get; set; }

        [Required]
        public string ValueDescription { get; set; }
        //public List<test2>? Tests2 { get; set; } = null;




    }
}
