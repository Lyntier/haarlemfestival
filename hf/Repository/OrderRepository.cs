using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using hf.Models;


namespace hf.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private hfContext db = new hfContext();

        public bool CheckifKeyExist(string key)
        {
            Order order = db.Orders.FirstOrDefault(m => m.OrderKey == key);
            if (order == null)
                return false;
            return true;
        }

        public void CreateOrder(Order order)
        {
            //add order
            db.Orders.Add(order);
            
            
            //add tickets
            foreach(Ticket ticket in order.Tickets)
            {
                db.Tickets.Add(ticket);
                //update sold tickets
                ticket.Event.SoldTickets = ticket.Event.SoldTickets + ticket.Amount;
                
            }
            db.SaveChanges();
        }

        public Order GetLastOrder()
        {
            Order order = db.Orders.Last();
            return order;
        }

        public Event GetEventByEvent(Event @event)
        {
            Event Event = db.Events.First(d => d.Name == @event.Name && d.Category == @event.Category && d.Location == @event.Location);
            return Event;
        }


    }
}