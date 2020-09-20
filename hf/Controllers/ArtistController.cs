using System;
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
    public class ArtistController : Controller
    {
        private ArtistRepository db = new ArtistRepository();

        // GET: Artist
        public ActionResult Index()
        {
            return null;
        }

        //GetArtist By Name for Timetable to info
        public JsonResult GetArtistByName(string Name) {
            IEnumerable<Artist> artist = db.GetArtistByName(Name);
            Console.Write(artist);
            JsonResult Artistjson = new JsonResult();
            Artistjson.Data = artist;
            return Artistjson;
        }

    }
}
