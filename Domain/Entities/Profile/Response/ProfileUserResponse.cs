using Domain.Entities.Subscriptions.Response;

namespace Domain.Entities.Profile.Response
{
    public class ProfileUserResponse
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string CustomerId { get; set; }

        public string SubscriptionId { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public bool IsPhoneNumberConfirmed { get; set; }

        public string Role { get; set; }

        public ProfileSubscriptionResponse Subscription { get; set; }
    }
}
