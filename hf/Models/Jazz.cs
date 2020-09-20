using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hf.Models
{
    [Table("Jazz")]
    public class Jazz : Event
    {
        public virtual Artist JazzArtist { get; set; }
        public int ArtistId { get; set; }
        public string Hall { get; set; }
    }
}