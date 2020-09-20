using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace hf.Models
{
    [Table("Dance")]
    public class Dance : Event
    {
        public Artist DanceArtist { get; set; }
        public string Venue { get; set; }
    }
}