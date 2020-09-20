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
using hf.ViewModels;

namespace hf.Controllers
{
    public class HistoricController : Controller
    {

        private IHistoricRepository HistoricRepo = new HistoricRepository();

        // GET: Historic
        public ActionResult Index()
        {
            HistoricViewModel historicViewModel = new HistoricViewModel();
            historicViewModel.PageInfo = GetPageInfo();
            historicViewModel.HistoricLocation = GetHistoricLocation();
            return View(historicViewModel);
        }

        private IEnumerable<HistoricLocation> GetHistoricLocation()
        {
            IEnumerable<HistoricLocation> historicLocation = HistoricRepo.GetHistoricLocation();
            return historicLocation;
        }

        public PageInfo GetPageInfo()
        {
            PageInfo historic = HistoricRepo.GetHistoricInfo();
            return historic;
        }
    }
}
