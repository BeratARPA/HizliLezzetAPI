using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class ProductMaterial : BaseEntity
    {
        public Guid RestaurantId { get; set; }
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public bool IsDefault { get; set; }
        public decimal Quantity { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual Product Product { get; set; }
    }
}
