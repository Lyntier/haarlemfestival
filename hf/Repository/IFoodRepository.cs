using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hf.Models;

namespace hf.Repository
{
    interface IFoodRepository
    {
        PageInfo GetFoodInfo();
        IEnumerable<Cuisine> GetAllCuisines();
        IEnumerable<Restaurant> GetAllRestaurants();
        IEnumerable<Restaurant> FilterOnCuisine(Cuisine type);
        Restaurant FilterOnRestaurant(Restaurant name);
    }
}