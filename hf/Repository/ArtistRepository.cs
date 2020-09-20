using hf.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data.Entity;

namespace hf.Repository
{
    public class ArtistRepository:IArtistRepository
    {
        private hfContext db = new hfContext();
        //Calls the db to use a where statement to get the right Event
        public IEnumerable<Artist> GetArtistByName(string Name)
        {
            IEnumerable<Artist> Artists = db.Artists.Where(d => d.Name == Name);

            return Artists;
        }
    }
}