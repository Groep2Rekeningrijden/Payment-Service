namespace PaymentService.DTOs.Pricing
{
    public class UpdatePricingDTO
    {
        public Guid Id { get; set; }
        public string PriceTitle { get; set; }
        public string PriceType { get; set; }
        public int ValueName { get; set; }
        public string ValueDescription { get; set; }
    }
}
