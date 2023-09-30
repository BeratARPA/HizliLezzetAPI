using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class RestaurantTableSection : BaseEntity
    {
        public Guid RestaurantId { get; set; }
        public char TableKeyword { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<RestaurantTable> RestaurantTables { get; set; }
    }
}
