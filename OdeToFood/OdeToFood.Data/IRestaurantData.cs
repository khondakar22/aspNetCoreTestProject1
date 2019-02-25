using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updateRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
                {
                    new Restaurant {Id = 1, Name = "Scoot's Pizza", Location="Maryland", Cuisine=CuisineType.Mexcian},
                    new Restaurant {Id = 2, Name = "Cinnamon Club", Location="London", Cuisine=CuisineType.Italian},
                    new Restaurant {Id = 3, Name = "La Costa", Location="California", Cuisine=CuisineType.Indian},

                };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from re in restaurants
                   where string.IsNullOrEmpty(name) || re.Name.StartsWith(name)
                   orderby re.Name
                   select re;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updateRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }

            return restaurant; 
        }

        public int Commit()
        {
            return 0;
        }
    }



}
