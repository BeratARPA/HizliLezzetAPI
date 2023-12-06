using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class RestaurantOwner : BaseEntity
    {
        public Guid UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
