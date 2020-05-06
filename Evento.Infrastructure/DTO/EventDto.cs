using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Infrastructure.DTO
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public DateTime UpdateAt { get;  set; }
        public int TicketsCount { get;  set; }
        public int PurchasedTicketsCount { get; set; }
        public int AvailableTicketsCount { get; set; }

    }
}
