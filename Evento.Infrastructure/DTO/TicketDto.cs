using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Infrastructure.DTO
{
    public class TicketDto
    {
        public Guid id { get;  set; }         //Id wydarzenia powiązanego z biletem
        public int Seating { get;  set; }
        public decimal Price { get;  set; }
        public Guid? UserId { get;  set; }
        public string Username { get;  set; }
        public DateTime? PurchaseAt { get;  set; }        //Data zakupu biletu
        public bool Purchased => UserId.HasValue;  //Czy bilet został zakupiony
    }
}
