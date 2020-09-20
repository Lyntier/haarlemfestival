using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hf.Models
{
    public class JazzVM
    {
        public PageInfo pageInfo { get; set; }
        public IEnumerable<DateTime> DateTimes { get; set; }
    }
}