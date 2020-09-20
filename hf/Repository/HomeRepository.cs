using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hf.Models;

namespace hf.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private hfContext db = new hfContext();
        public PageInfo GetPageInfo()
        {
            return db.PageInfoes.FirstOrDefault(m => m.Category == "Home");
        }
    }
}