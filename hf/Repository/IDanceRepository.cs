using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hf.Models;

namespace hf.Repository
{
    interface IDanceRepository
    {
        Artist GetArtistById(int id);
        Artist GetArtistByName(string name);
        void InsertDance(Dance dance);
        PageInfo GetDanceInfo();
        IEnumerable<Dance> GetDanceEventByDay(int day);
        List<DateTime> GetDanceEventDay();
        IEnumerable<Event> GetDanceEventByName(string Name);
    }
}
