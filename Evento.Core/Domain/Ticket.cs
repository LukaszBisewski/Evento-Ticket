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
        public DateTime? PurchasedAt { get; protected set; }        //Data zakupu biletu
        public bool Purchased => UserId.HasValue;  //Czy bilet został zakupiony

        protected Ticket()
        {

        }
        public Ticket(Event @event, int seating, decimal price) //Przekazujemy event, bilet zawsze jest przypisany do wydarzenia
        {
            EventId = @event.Id;
            Seating = seating;
            Price = price;
        }

        public void Purchase(User user)
        {
            if (Purchased)
            {
                throw new Exception("Ticket was allready purchased by user: '{Username}' at '{PurchaseAt}'");
            }
            UserId = user.Id;
            Username = user.Name;
            PurchasedAt = DateTime.UtcNow;
        }
        public void Cancel()
        {
            if (!Purchased)
            {
                throw new Exception($"Ticket was not purchased and can not be canceled.");
            }
            UserId = null;
            Username = null;
            PurchasedAt = null;
        }
    }
}