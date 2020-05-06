﻿using System;
using System.Collections.Generic;
using System.Linq;


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
        public IEnumerable<Ticket> PurchasedTickets => Tickets.Where(x => x.Purchased);  //  Kolekcja zakupionych biletów 
        public IEnumerable<Ticket> AvailableTickets => Tickets.Where(x => !x.Purchased);  // =>Tickets.Except(PurchasedTickets); // Kolekcja zakupionych biletów 

        protected Event()
        {

        }
        public Event(Guid id, string name, string description, DateTime startDate, DateTime endDate)
        {
            Id = id;
            SetName(name);
            SetDescription(description);
            StartDate = startDate;
            EndDate = endDate;
            CreatedAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
        }

        public void AddTicket(int amount, decimal price)                 //Ilość biletów, cena pojedyńczego biletu
        {
            var seating = _tickets.Count + 1;
            for (var i = 0; i < amount; i++)
            {
                _tickets.Add(new Ticket(this, seating, price));
                seating++;
            }

        }
        public void SetName(string name)                    //to update Event Name
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Event with id: '{Id}' can not have an empty name.");
            }
            Name = name;
            UpdateAt = DateTime.UtcNow;
        }

        public void SetDescription(string description)  //to update Event Description
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception($"Event with id: '{Id}' can not have an empty description.");
            }
            Description = description;
            UpdateAt = DateTime.UtcNow;
        }
        public void PurchaseTickets(User user, int amount)
        {
            if (AvailableTickets.Count() < amount)
            {
                throw new Exception($"Not enough available tickets to purchase ({amount}) by user: '{user.Name}'.");
            }
            var tickets = AvailableTickets.Take(amount);
            foreach (var ticket in tickets)
            {
                ticket.Purchase(user);
            }
        }

        public void CancelPurchasedTickets(User user, int amount)
        {
            var tickets = PurchasedTickets.Where(x => x.UserId == user.Id);
            if (tickets.Count() < amount)
            {
                throw new Exception($"Not enough purchased tickets to be canceled ({amount}) by user: '{user.Name}'.");
            }
            foreach (var ticket in tickets)
            {
                ticket.Cancel();
            }
        }
    }
}


