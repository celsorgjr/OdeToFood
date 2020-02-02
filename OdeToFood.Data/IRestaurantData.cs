using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetByID(int Id);
        Restaurant Update(Restaurant UpdateRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int Id);
        int Commit();
    }
}
