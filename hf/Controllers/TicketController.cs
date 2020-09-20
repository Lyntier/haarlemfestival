using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hf.Models;
using hf.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace hf.Controllers
{
    public class TicketController : Controller
    {
        private hfContext db = new hfContext();
        private ITicketRepository ticketRepository = new TicketRepository();
        private List<Ticket> tickets = new List<Ticket>();

        // GET: Ticket
        public ActionResult Index()
        {
            try
            {
                tickets = Session["Cart"] as List<Ticket>;
            } catch
            {
                
            }
            
            return View(tickets);
        }

        [HttpGet]
        public ActionResult ViewOrder(string orderkey)
        {

            return View();
        }

     
        [HttpPost]
        public void FillSession(Event ticketevent, int eventamount)
        {

            Ticket ticket = new Ticket() {
                Event = ticketevent,
                Amount = eventamount,
                TotalPrice = eventamount * ticketevent.Price
            };

            //check session if exist
            if (Session["Cart"] == null)
            {
                Session["Cart"] = tickets;
                tickets.Add(ticket);
            }
            else
            {
                tickets = Session["Cart"] as List<Ticket>;

                bool ticketExists = ticketexist(ticket);


                if(ticketExists == true)
                {
                
                    //items groeperen
                    foreach (Ticket item in tickets)
                    {
                   
                        if (item.Event.Name == ticket.Event.Name)
                        {
                            item.Amount = item.Amount + ticket.Amount;
                            item.TotalPrice = item.TotalPrice + ticket.TotalPrice;
                        }

                    }
                } else
                {
                    tickets.Add(ticket);
                }
            }
        }
        //check if ticket exist in list tickets
        private bool ticketexist(Ticket ticket)
        {
            foreach (Ticket item in tickets)
            {
                if (item.Event.Name == ticket.Event.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public ActionResult Delete (int eventId, decimal totalPrice)
        {
            Ticket itemticket = new Ticket();
            if (Session["Cart"] != null)
            {
                tickets = Session["Cart"] as List<Ticket>;
            }
            
            foreach (Ticket ticket in tickets)
            {
                if(ticket.Event.Id == eventId && ticket.TotalPrice == totalPrice)
                {
                    itemticket = ticket;
                    
                }
            }
            int index = tickets.IndexOf(itemticket);
            tickets.RemoveAt(index);

            return RedirectToAction("Index");
            
        }

   

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
