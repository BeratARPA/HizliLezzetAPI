using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class LimitedMaterial : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }

        public virtual Product Product { get; set; }
    }
}
