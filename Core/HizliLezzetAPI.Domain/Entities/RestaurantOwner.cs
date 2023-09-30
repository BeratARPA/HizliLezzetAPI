using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class RestaurantOwner : BaseEntity
    {
        public Guid UserId { get; set; }
    }
}
