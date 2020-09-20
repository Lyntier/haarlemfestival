using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hf.Models;

namespace hf.ViewModels
{
    public class FoodViewModel
    {
        public PageInfo PageInfo { get; set; }
        public IEnumerable<Cuisine> CuisineList { get; set; }
        public IEnumerable<Restaurant> RestaurantList { get; set; }
        public IEnumerable<Restaurant> GetRestaurants { get; set; }
        public Restaurant GetDetails { get; set; }
    }
}