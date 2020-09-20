using System.Collections.Generic;
using System.Web.Mvc;
using hf.Models;
using hf.Repository;
using hf.ViewModels;
using System.Data.Entity;

namespace hf.Controllers
{
    public class FoodController : Controller
    {
        private IFoodRepository foodRepository = new FoodRepository();

        // GET: Food

        public ActionResult Index(Cuisine cuisine, Restaurant name)
        {
            FoodViewModel foodViewModel = new FoodViewModel();
            foodViewModel.PageInfo = GetPageInfo();
            foodViewModel.CuisineList = GetCuisines();
            foodViewModel.RestaurantList = GetRestaurants();
            foodViewModel.GetRestaurants = FilterRestaurantOnCuisine(cuisine);
            foodViewModel.GetDetails = FilterRestaurantDetails(name);
            return View(foodViewModel);
        }

        public PageInfo GetPageInfo()
        {
            PageInfo food = foodRepository.GetFoodInfo();
            return food;
        }

        public IEnumerable<Cuisine> GetCuisines()
        {
            IEnumerable<Cuisine> cuisines = foodRepository.GetAllCuisines();
            return cuisines;
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            IEnumerable<Restaurant> restaurants = foodRepository.GetAllRestaurants();
            return restaurants;
        }

        public IEnumerable<Restaurant> FilterRestaurantOnCuisine(Cuisine cuisine)
        {
            IEnumerable<Restaurant> restaurants = foodRepository.FilterOnCuisine(cuisine);
            return restaurants;
        }

        Restaurant FilterRestaurantDetails(Restaurant name)
        {
            Restaurant restaurantDetails = foodRepository.FilterOnRestaurant(name);
            return restaurantDetails;
        }
    }
}