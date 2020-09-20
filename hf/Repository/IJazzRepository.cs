using hf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hf.Repository
{
    interface IJazzRepository
    {
        Artist GetArtistById(int id);
        void InsertJazz(Jazz jazz);
        PageInfo GetJazzInfo();
        IEnumerable<Jazz> GetJazzEventByDay(int day);
        IEnumerable<Jazz> GetAllAccessPass();
        Event GetEventByEvent(Event @event);
        IEnumerable<DateTime> GetAlljazzdates();
    }
}
