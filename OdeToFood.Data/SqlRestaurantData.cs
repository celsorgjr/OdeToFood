using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = GetByID(Id);
            if (restaurant != null){
                db.Remove(restaurant);
            }
            return restaurant;

        }

        public Restaurant GetByID(int Id)
        {
            return db.Restaurants.Find(Id); 
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant UpdateRestaurant)
        {
            var entity = db.Restaurants.Attach(UpdateRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return UpdateRestaurant;
        }
    }
}
