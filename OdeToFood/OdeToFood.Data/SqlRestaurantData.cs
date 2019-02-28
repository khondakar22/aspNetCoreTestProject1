using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _dbContext;

        public SqlRestaurantData(OdeToFoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in _dbContext.Restaurants
                where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                orderby r.Name
                select r;
            return query;

        }

        public Restaurant GetById(int id)
        {
            return _dbContext.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity = _dbContext.Restaurants.Attach(updateRestaurant);
            entity.State = EntityState.Modified;
            return updateRestaurant;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            _dbContext.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                _dbContext.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}