using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hf.Models;
using hf.Repository;

namespace hf.Controllers
{
    public class OrderController : Controller
    {
        private IEnumerable<Ticket> tickets = new List<Ticket>();
        private IOrderRepository repoOrder = new OrderRepository();

        // GET: Order
        [HttpGet]
        public ActionResult Index()
        {
             //check cart session en slaat het op in globaal variabel tickets
            if(Session["Cart"] != null)
            {
                tickets = Session["Cart"] as List<Ticket>;
            }
            return View();
        }

       
        // Create new order
        [HttpPost]
        public ActionResult Index(string userMail)
        {
            //check cart session en slaat het op in globaal variabel tickets
            if (Session["Cart"] != null)
            {
                tickets = Session["Cart"] as List<Ticket>;
            }

            //check if key already exists
            string key = GenerateKey();
            bool isUniekkey = repoOrder.CheckifKeyExist(key);

            do {
                key = GenerateKey();
                isUniekkey = repoOrder.CheckifKeyExist(key);
            } while (isUniekkey == true);

            //create order object
            Order order = new Order()
            {
                PaymentReceived = true,
                OrderKey = key,
                Tickets = tickets,
                Email = userMail,
            };
            //modify tickets and add order
            foreach (Ticket ticket in tickets)
            {
                ticket.OrderId = order.Id;
                ticket.Order = order;
                ticket.Event = repoOrder.GetEventByEvent(ticket.Event);
            }

            //modify order
            order.Tickets = tickets;
           

            string orderStatus = "There was something wrong.";

            if (tickets != null)
            {
                repoOrder.CreateOrder(order);   

                orderStatus = "Successfully ordered!";
            }
            return RedirectToAction("orderStatus", "Order", new { status = orderStatus, orderkey = key});
        }

        private string GenerateKey()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringchars = new char[8];
            Random random = new Random();

            for (int i = 0; i < stringchars.Length; i++)
            {
                stringchars[i] = chars[random.Next(chars.Length)];
            }
            String finalstring = new String(stringchars);
            return finalstring;
        }

        public ActionResult orderStatus(string status, string orderkey)
        {
            ViewBag.orderStatus = status;
            ViewBag.key = orderkey;

            //clear session
            Session.Clear();
            return View();
        }

       

      
        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

       
    }
}
