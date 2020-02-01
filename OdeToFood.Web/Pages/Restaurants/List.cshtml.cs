using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Web.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration Configuration;
        private readonly IRestaurantData RestaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            Configuration = configuration;
            this.RestaurantData = restaurantData;
        }

        public void OnGet()
        {
            Message = Configuration["Message"];
            Restaurants = RestaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}
