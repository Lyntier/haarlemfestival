using hf.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data.Entity;

namespace hf.Repository
{
    public class DanceRepository : IDanceRepository
    {

        private hfContext db = new hfContext();

        
       

        public Artist GetArtistByName(string name)
        {
            throw new NotImplementedException();
        }
        //Dance events by day for the timetable
        public IEnumerable<Dance> GetDanceEventByDay(int day)
        {
            IEnumerable<Dance> lijstDance = db.Dances
                                .Include(b => b.DanceArtist)
                                .Where(d => d.Starttime.Day == day && d.Category == "dance")
                                .ToList();

            return lijstDance;
        }
        //To get the description to be modifiable through the admin panel we needed it to be in the database this way you get it to the page.
        public PageInfo GetDanceInfo()
        {
            return db.PageInfoes.FirstOrDefault(m => m.Category.Equals("dance"));
        }

        public void InsertDance(Dance dance)
        {
            db.Dances.Add(dance);
            db.SaveChanges();
        }

        public IEnumerable<Dance> GetAll()
        {
            return db.Dances.ToList();
        }
        public Artist GetArtistById(int id)
        {
            return db.Artists.Find(id);
        }
        public List<DateTime> GetDanceEventDay()
        {
            List<DateTime> lijstDanceDay = db.Dances
                                 .Where(s => s.Category == "dance")
                                 .Select(s => s.Starttime).Distinct()
                                 .ToList();

            List<DateTime> days = new List<DateTime>();
            for (int i = 0; i < lijstDanceDay.Count(); i++)
            {
                DateTime input = lijstDanceDay[i].Date;
                if (days != null)
                {
                    for (int index = 0; index < days.Count; index++)
                    {
                        if (days[index] == input)
                        {

                        }
                        else if (days.Count - 1 == index)
                        {
                            days.Add(input);
                        }
                    }
                }
                if (i == 0) { days.Add(input); }

            }

            return days;
        }

        public IEnumerable<Event> GetDanceEventByName(string Name)
        {
            IEnumerable<Event> lijstDance = db.Events
                                .Where(d => d.Name == Name && d.Category == "dance").ToList();
            IEnumerable<Event> test = lijstDance;
            var t = lijstDance;
            return lijstDance;
        }
    }
}