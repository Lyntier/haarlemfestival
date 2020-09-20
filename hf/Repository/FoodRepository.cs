using System.Collections.Generic;
using System.Linq;
using hf.Models;
using System.Data.Entity;

namespace hf.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private hfContext db = new hfContext();

        public PageInfo GetFoodInfo()
        {
            return db.PageInfoes.FirstOrDefault(m => m.Category.Equals("Food"));
        }

        // Lijst van alle cuisines weergeven
        public IEnumerable<Cuisine> GetAllCuisines()
        {
            IEnumerable<Cuisine> cuisineList = db.Cuisines;
            return cuisineList;
        }

        // Lijst van alle restaurants weergeven
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            IEnumerable<Restaurant> restaurantList = db.Restaurants;
            return restaurantList;
        }
        

        // Lijst weergeven van gefilterde restaurants
        public IEnumerable<Restaurant> FilterOnCuisine(Cuisine cuisine)
        {
            IEnumerable<Restaurant> restaurantByCuisine = db.Restaurants.Include(x => x.Cuisines).ToList();
            return restaurantByCuisine;
        }

        // Geen lijst weergeven (!!!)
        public Restaurant FilterOnRestaurant(Restaurant name)
        {
            Restaurant restaurantDetails = db.Restaurants.Find(name.Name);
            return restaurantDetails;
        }

        public IEnumerable<Food> GetAll()
        {
            return db.Foods.Include(r => r.Restaurant).ToList();
        }
    }
}