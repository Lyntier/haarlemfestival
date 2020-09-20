using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace hf.Models
{
    [Table("Food")]
    public class Food : Event
    {
        public Restaurant Restaurant { get; set; }
        public string Note { get; set; }
    }
}