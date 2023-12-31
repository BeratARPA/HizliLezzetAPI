﻿namespace HizliLezzetAPI.Application.Dtos
{
    public class TicketViewDto
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid RestaurantTableId { get; set; }
        public string TicketNumber { get; set; }
        public bool IsOpened { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public string TerminalName { get; set; }
        public string TerminaIPAddress { get; set; }
        public string Note { get; set; }
        public string CreatedUserName { get; set; }
        public string LastModifiedUserName { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public DateTime LastOrderDateTime { get; set; }
        public DateTime LastPaymentDateTime { get; set; }
    }
}
