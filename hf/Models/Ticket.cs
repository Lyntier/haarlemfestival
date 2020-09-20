using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hf.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
        public Event Event { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}