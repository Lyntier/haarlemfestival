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
    public class JazzController : Controller
    {
        private IJazzRepository JazzRepo = new JazzRepository();

        // GET: Jazz
        public ActionResult Index()
        {
            JazzVM jazzVM = new JazzVM();
            jazzVM.pageInfo = JazzRepo.GetJazzInfo();
            jazzVM.DateTimes = getJazzdate();
            return View(jazzVM);
        }

        private IEnumerable<DateTime> getJazzdate()
        {
            IEnumerable<DateTime> alldates = JazzRepo.GetAlljazzdates();
            List<DateTime> distinctdate = new List<DateTime>();
            foreach(DateTime date in alldates)
            {
                DateTime newdate = date.Date;
                bool j = distinctdate.Contains(newdate);
                if (j == false)
                {
                    distinctdate.Add(newdate);
                }
            }
            IEnumerable<DateTime> list = distinctdate.OrderBy(x => x.Day);
            return list;
        }

        public ActionResult AllAccesspass()
        {
            IEnumerable<Jazz> allAccessPass = JazzRepo.GetAllAccessPass();
            return View(allAccessPass);
        }

        public JsonResult GetAccesspass()
        {
            IEnumerable<Jazz> allAccessPass = JazzRepo.GetAllAccessPass();
            JsonResult jsonResult = new JsonResult() { Data = allAccessPass };
            return jsonResult;

        }

        //get jazz event by day via ajax
        public JsonResult GetJazzEventByDay(int day)
        {
            IEnumerable<Jazz> jazzevent = JazzRepo.GetJazzEventByDay(day);
            JsonResult jazzjson = new JsonResult();
            jazzjson.Data = jazzevent;
            return jazzjson;
        }

       

      

   

    }
}
