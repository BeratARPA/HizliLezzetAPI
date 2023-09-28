using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid TicketId { get; set; }
        public Guid SpecialProductId { get; set; }
        public decimal TotalPrice { get; set; }
        public string TerminalName { get; set; }
        public string TerminaIPAddress { get; set; }
        public string CreatedUserName { get; set; }
        public string LastModifiedUserName { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }     
    }
}
