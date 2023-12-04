namespace HizliLezzetAPI.Application.Dtos
{
    public class PaymentViewDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string TerminalName { get; set; }
        public string TerminaIPAddress { get; set; }
        public decimal Amount { get; set; }
        public decimal TenderedAmount { get; set; }
    }
}
