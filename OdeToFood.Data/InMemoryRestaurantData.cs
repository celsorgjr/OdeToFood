using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> Restaurants;

        public InMemoryRestaurantData()
        {
            Restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Celso's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Indian},
                new Restaurant {Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican}
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            Restaurants.Add(newRestaurant);
            newRestaurant.Id = Restaurants.Max(c => c.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant GetByID(int Id)
        {
            return Restaurants.SingleOrDefault(c => c.Id == Id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in Restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name 
                   select r;
        }

        public Restaurant Update(Restaurant UpdateRestaurant)
        {
            var restaurant = GetByID(UpdateRestaurant.Id);
            if (restaurant!= null)
            {
                restaurant.Name = UpdateRestaurant.Name;
                restaurant.Location = UpdateRestaurant.Location;
                restaurant.Cuisine = UpdateRestaurant.Cuisine;
            }            
            return restaurant;
        }
    }
}
