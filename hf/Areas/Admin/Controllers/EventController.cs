using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hf.Models;
using hf.Repository;

namespace hf.Areas.Admin.Controllers
{
    public class EventController : AuthorizedController
    {
        private EventRepository eventRepository = new EventRepository();

        // GET: Admin/Event
        /// <summary>
        /// Loads the page containing the wrapper for the timetables and the events.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Updates the event with the given ID in the database, replacing the
        /// values of its fields with the ones in the parameters. Then, reloads
        /// the event page with the new information.
        /// </summary>
        /// <param name="id">ID of the event to change</param>
        /// <param name="name">Name to give the event</param>
        /// <param name="starttime">Start time of the event</param>
        /// <param name="endtime">End time of the event</param>
        /// <param name="price">Price of the event</param>
        /// <param name="amountoftickets">Amount of tickets the event can sell at maximum</param>
        /// <returns>A redirect to the event page, updating the timetable in the process</returns>
        [HttpPost]
        public ActionResult UpdateEventData(Event currentEvent)
        {
            eventRepository.Update(currentEvent);
            return RedirectToAction("Index");
        }
    }
}