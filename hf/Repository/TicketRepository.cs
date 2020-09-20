using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hf.Models;
using System.Data.Entity;

namespace hf.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private hfContext db = new hfContext();

        public IEnumerable<Ticket> AllTickets()
        {
            throw new NotImplementedException();
        }

      

        public void InsertTicket(IEnumerable<Ticket> tickets, Order order)
        {
            foreach(Ticket ticket in tickets)
            {
                //place order
                ticket.Order = order;
                ticket.OrderId = order.Id;
                db.Tickets.Add(ticket);

                //minus amountoftickets
                int NewAmountofTickets = ticket.Event.AmountofTickets - ticket.Amount;
                ticket.Event.AmountofTickets = NewAmountofTickets;
            }
            db.SaveChanges();
        }

        
    }
}