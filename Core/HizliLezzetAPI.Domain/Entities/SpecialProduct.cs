using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class SpecialProduct : BaseEntity
    {
        public Guid RestaurantId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Product Product { get; set; }      
    }
}
