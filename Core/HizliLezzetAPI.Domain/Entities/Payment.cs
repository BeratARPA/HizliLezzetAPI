using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Guid TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string TerminalName { get; set; }
        public string TerminaIPAddress { get; set; }
        public decimal Amount { get; set; }
        public decimal TenderedAmount { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
