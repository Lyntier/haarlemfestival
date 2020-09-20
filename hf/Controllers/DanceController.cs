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
    public class DanceController : Controller
    {
        private hfContext db = new hfContext();
        private IDanceRepository DanceRepo = new DanceRepository();

        // Get Dance information for the webpage/view
        public ActionResult Index()
        {
            PageInfo dance = DanceRepo.GetDanceInfo();
            return View(dance);
        }
        //Used to get the JSON result of the Repository to the called function or AJAX call in this case
        public JsonResult GetDanceEventByDay(int day)
        {
            IEnumerable<Dance> danceevent = DanceRepo.GetDanceEventByDay(day);
            JsonResult dancejson = new JsonResult();
            dancejson.Data = danceevent;
            return dancejson;
        }


        public JsonResult GetArtistById(int id)
        {
            Artist artist = DanceRepo.GetArtistById(id);
            JsonResult artistJson = new JsonResult();
            artistJson.Data = artist;
            return artistJson;
        }

        public JsonResult GetDanceEventDay()
        {
            List<DateTime> danceday = DanceRepo.GetDanceEventDay();
            JsonResult dancejson = new JsonResult();
            dancejson.Data = danceday;
            return dancejson;
        }
        public JsonResult GetDanceEventByName(string Name) {
            IEnumerable<Event> danceevent = DanceRepo.GetDanceEventByName(Name);
            Console.Write(danceevent);
            Console.Write("test");
            JsonResult dancejson = new JsonResult();
            dancejson.Data = danceevent;
            return dancejson;
        }
    }
}
