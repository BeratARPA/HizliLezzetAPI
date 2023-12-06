using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class RestaurantTable : BaseEntity
    {
        public Guid RestaurantTableSectionId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }

        public virtual RestaurantTableSection RestaurantTableSection { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
