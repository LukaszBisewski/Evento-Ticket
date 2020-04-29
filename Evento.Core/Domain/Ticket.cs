using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Domain
{
    public class Ticket : Entity
    {
        public Guid EventId { get; protected set; }         //Id wydarzenia powiązanego z biletem
        public int Seating { get; protected set; }
        public decimal Price { get; protected set; }
        public Guid? UserId { get; protected set; }
        public string Username { get; protected set; }
        public DateTime? PurchaseAt { get; protected set; }        //Data zakupu biletu
        public bool Purchased => UserId.HasValue;  //Czy bilet został zakuipiony

        protected Ticket()
        {

        }
        public Ticket(Event @event, int seating, decimal price) //Przekazujemy event, bilet zawsze jest przypisany do wydarzenia
        {
            EventId = @event.Id;
            Seating = seating;
            Price = price;
        }
    }
}
