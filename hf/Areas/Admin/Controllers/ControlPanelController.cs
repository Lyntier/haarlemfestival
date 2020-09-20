using hf.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using hf.Models;

namespace hf.Areas.Admin.Controllers
{
    public class ControlPanelController : AuthorizedController
    {
        private EventRepository eventRepository = new EventRepository();
        private JazzRepository jazzRepository = new JazzRepository();
        private DanceRepository danceRepository = new DanceRepository();
        private WalkRepository walkRepository = new WalkRepository();
        private FoodRepository foodRepository = new FoodRepository();

        private const string _partialViewPath = "~/Areas/Admin/Views/Event/Partial/";

        // GET: Admin/ControlPanel
        /// <summary>
        /// Returns the homepage of the ControlPanel. Used as a landing page after logging
        /// in without a redirect URL.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns the page that contains the timetable with
        /// all events in the festival.
        /// </summary>
        /// <returns></returns>
        public PartialViewResult EventTimetable()
        {
            return PartialView(_partialViewPath + "_Event.cshtml");
        }

        /// <summary>
        /// Returns the page that contains the timetable with
        /// all Jazz-related events in the festival.
        /// </summary>
        /// <returns></returns>
        public PartialViewResult JazzTimetable()
        {
            return PartialView(_partialViewPath + "_Jazz.cshtml");
        }

        /// <summary>
        /// Returns the page that contains the timetable with
        /// all Dance-related events in the festival.
        /// </summary>
        /// <returns></returns>
        public PartialViewResult DanceTimetable()
        {
            return PartialView(_partialViewPath + "_Dance.cshtml");
        }

        /// <summary>
        /// Returns the page that contains the timetable with
        /// all Walk-related events in the festival. 
        /// </summary>
        /// <returns></returns>
        public PartialViewResult WalkTimetable()
        {
            return PartialView(_partialViewPath + "_Walk.cshtml");
        }

        /// <summary>
        /// Returns the page that contains the timetable with
        /// all Food-related events in the festival.
        /// </summary>
        /// <returns></returns>
        public PartialViewResult FoodTimetable()
        {
            return PartialView(_partialViewPath + "_Food.cshtml");
        }

        /// <summary>
        /// Renders the partial view for editing an event. 
        /// </summary>
        /// <returns></returns>
        public PartialViewResult SeparateEvent(int id)
        {
            Event currentEvent = eventRepository.GetById(id);
            return PartialView(_partialViewPath + "_EditEvent.cshtml", currentEvent);
        }

        /// <summary>
        /// Returns an event with a given Id, wrapped in a string (for Ajax-calls).
        /// Needed for some refresh-dependant calls.
        /// </summary>
        /// <param name="eventId">ID to query events on.</param>
        /// <returns>Event with the given ID, as JSON.</returns>
        [HttpPost]
        public JsonResult GetEvent(string eventId)
        {
            JsonResult result = new JsonResult();

            Event currentEvent = eventRepository.GetById(int.Parse(eventId));

            result.Data = currentEvent;
            return result;

        }

        /// <summary>
        /// Returns all events with a given event type, as a generic event.
        /// </summary>
        /// <param name="eventType">The event type to take events from. If null,
        /// all events are queried.</param>
        /// <returns>Events with the given event type, as JSON.</returns>
        [HttpPost]
        public JsonResult GetEvents(string eventType)
        {
            JsonResult result = new JsonResult();

            if (eventType == null) result.Data = eventRepository.GetAll();
            else if (eventType == "jazz") result.Data = jazzRepository.GetAll();
            else if (eventType == "dance") result.Data = danceRepository.GetAll();
            else if (eventType == "food") result.Data = foodRepository.GetAll();
            else if (eventType == "walk") result.Data = walkRepository.GetAll();

            return result;
        }
    }
}