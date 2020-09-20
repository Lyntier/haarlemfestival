using hf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace hf.Repository
{
    public class JazzRepository : IJazzRepository
    {
        private hfContext db = new hfContext();

        public IEnumerable<Jazz> GetAllAccessPass()
        {
            Jazz jazz = db.Jazzs.Where(d => d.Name == "All-Access Pass").FirstOrDefault();

            IEnumerable<Jazz> allAccesspasses = db.Jazzs
                                                .Where(d => d.Name == "All-Access Pass")
                                                .ToList();
            return allAccesspasses;
        }

       

        public Artist GetArtistById(int id)
        {
            return db.Artists.Find(id);
        }

        

        public IEnumerable<Jazz> GetJazzEventByDay(int day)
        {
            IEnumerable<Jazz> lijstjazz = db.Jazzs
                                .Include(b => b.JazzArtist)
                                .Where(d => d.Starttime.Day == day && d.Category == "jazz" && d.Name != "All-Access Pass")
                                .ToList();

            return lijstjazz;
        }

        public Event GetEventByEvent(Event @event)
        {
            Jazz jazz = db.Jazzs.First(d => d.Name == @event.Name && d.Category == @event.Category && d.Location == @event.Location); 
            return jazz;
        }

        public PageInfo GetJazzInfo()
        {
            return db.PageInfoes.FirstOrDefault(m => m.Category.Equals("jazz"));
        }

        public void InsertJazz(Jazz jazz)
        {
            db.Jazzs.Add(jazz);
            db.SaveChanges();
        }

        public IEnumerable<Jazz> GetAll()
        {
            return db.Jazzs.ToList();
        }

        public IEnumerable<DateTime> GetAlljazzdates()
        {
            IEnumerable<DateTime> jazzs = db.Jazzs.Select(d => d.Starttime).ToList();
          
            return jazzs;
        }
    }
}