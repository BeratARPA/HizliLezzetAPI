using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class AdditionalSection : BaseEntity
    {
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
