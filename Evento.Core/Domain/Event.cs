using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Domain
{
    public class Event : Entity
    {
        private ISet<Ticket> _tickets = new HashSet<Ticket>();
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime UpdateAt { get; protected set; }
        public IEnumerable<Ticket> Tickets => _tickets;  //Dodawanie/usuwanie biletów w wydarzeniu

        protected Event()
        {

        }
        public Event(Guid id, string name, string description, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            CreatedAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
        }

        public void AddTicket(int amount, decimal price)                 //Ilość biletów, cena pojedyńczego biletu
        {
            var seating = _tickets.Count + 1;
            for(var i=0; i<amount; i++)
            {
                _tickets.Add(new Ticket(this, seating, price));
                seating++;
            }

        }
    }
}
