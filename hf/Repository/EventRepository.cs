using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hf.Models;

namespace hf.Repository
{
    public class EventRepository : GenericRepository<Event>
    {
        public Event GetById(int id)
        {
            Event currentEvent = _context.Events.Find(id);
            return currentEvent;
        }
    }
}