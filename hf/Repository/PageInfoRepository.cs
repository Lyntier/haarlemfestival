using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hf.Models;

namespace hf.Repository
{
    public class PageInfoRepository : GenericRepository<PageInfo>
    {
        public PageInfo GetById(int id)
        {
            return _context.PageInfoes.Find(id);
        }
    }
}