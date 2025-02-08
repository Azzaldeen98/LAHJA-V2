namespace Infrastructure.Models.Checkout.Request
{
    public class CheckoutRequestModel
    {
        public string? planId { get; set; }
        public string? successUrl { get; set; }
        public string? cancelUrl { get; set; }

    }



}
