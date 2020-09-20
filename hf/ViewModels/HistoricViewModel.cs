using hf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hf.ViewModels
{
    public class HistoricViewModel
    {
        public PageInfo PageInfo { get; set; }
        public IEnumerable<HistoricLocation> HistoricLocation { get; set; }
    }
}