using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hf.Models
{
    [Table("Historic")]
    public class Historic : Event
    {
        public List<HistoricLocation> Route { get; set; }
        public string Language { get; set; }
    }
}