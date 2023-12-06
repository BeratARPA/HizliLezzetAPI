using Microsoft.AspNetCore.Identity;

namespace HizliLezzetAPI.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        public virtual RestaurantOwner RestaurantOwner { get; set; }
    }
}
