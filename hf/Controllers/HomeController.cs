using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hf.Repository;
using hf.Models;

namespace hf.Controllers
{
    public class HomeController : Controller
    {
        IHomeRepository homeRepository = new HomeRepository();
        public ActionResult Index()
        {
            PageInfo homeInfo = homeRepository.GetPageInfo();
            return View(homeInfo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}