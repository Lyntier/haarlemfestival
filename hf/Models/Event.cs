using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hf.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int AmountofTickets { get; set; }
        public int SoldTickets { get; set; }
        public string Category { get; set; }
        
    }
}