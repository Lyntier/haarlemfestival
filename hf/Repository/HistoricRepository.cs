using hf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hf.Repository
{
    public class HistoricRepository : IHistoricRepository
    {
        private hfContext db = new hfContext();

        public PageInfo GetHistoricInfo()
        {
            return db.PageInfoes.FirstOrDefault(m => m.Category.Equals("Historic"));
        }

        public IEnumerable<HistoricLocation> GetHistoricLocation()
        {
            IEnumerable<HistoricLocation> historicLocation = db.HistoricLocations;
            return historicLocation;
        }
    }
}