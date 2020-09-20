using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using hf.Models;

namespace hf.Models
{
    public class Cuisine
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Restaurant> Restaurant { get; set; }
    }
} 