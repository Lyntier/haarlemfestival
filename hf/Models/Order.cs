using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hf.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public bool PaymentReceived { get; set; }
        public string Email { get; set; }
        public string OrderKey { get; set; }
    }
}