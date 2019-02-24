using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
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

    }



}
