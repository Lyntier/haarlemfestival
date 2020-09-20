using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hf.Models
{
    public class hfContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public hfContext() : base("name=hfContext")
        {
        }

        public System.Data.Entity.DbSet<hf.Models.Jazz> Jazzs { get; set; }

        public System.Data.Entity.DbSet<hf.Models.Dance> Dances { get; set; }

        public System.Data.Entity.DbSet<hf.Models.Food> Foods { get; set; }

        public System.Data.Entity.DbSet<hf.Models.Historic> Historics { get; set; }

        public System.Data.Entity.DbSet<hf.Models.Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<hf.Models.HistoricLocation> HistoricLocations { get; set; }

        public System.Data.Entity.DbSet<hf.Models.Login> Logins { get; set; }

        public System.Data.Entity.DbSet<hf.Models.Restaurant> Restaurants { get; set; }

        public System.Data.Entity.DbSet<hf.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<hf.Models.Ticket> Tickets { get; set; }

        public System.Data.Entity.DbSet<hf.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<hf.Models.PageInfo> PageInfoes { get; set; }

        public System.Data.Entity.DbSet<hf.Models.Cuisine> Cuisines { get; set; }
    }
}
