using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class ProductCategory : BaseEntity
    {
        public Guid RestaurantId { get; set; }
        public bool PreperationType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
