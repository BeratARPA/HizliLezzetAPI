using System.ComponentModel.DataAnnotations;

namespace HizliLezzetAPI.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
