using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hf.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public virtual ICollection<Cuisine> Cuisines { get; set; }
    }
}