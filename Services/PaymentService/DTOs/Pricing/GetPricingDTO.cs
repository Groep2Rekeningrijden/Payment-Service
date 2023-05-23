using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace PaymentService.DTOs.Pricing
{
    public class GetPricingDTO
    {
        public Guid Id { get; set; }
        public string PriceTitle { get; set; }
        public string PriceType { get; set; }
        public string ValueName { get; set; }
        public int ValueDescription { get; set; }

    }
}
