
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApps.Views
{
    public partial class Restaurants : ContentPage
    {
        public Restaurants()
        {
            InitializeComponent();
            RestaurantListView.ItemSelected += async (sender, e) =>
            {
                Restaurant rest = e.SelectedItem as Restaurant;
                if (e.SelectedItem != null)
                {

                    await Navigation.PushAsync(new NavigationPage(new RestaurantDetails(rest)));



                }
                RestaurantListView.SelectedItem = null;
            };


        }
        protected override async void OnAppearing()
        {
            await GetRestaurant();
        }
        List<Restaurant> getListFromJson(string json)
        {
            var Restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);


            return Restaurants;
        }

        public static List<Restaurant> Restaurant;
        public async Task GetRestaurant()
        {

            var client = new HttpClient();


            var json = await client.GetStringAsync("http://192.168.0.111:55469/api/restaurants");
            Restaurant = getListFromJson(json);
            RestaurantListView.ItemsSource = Restaurant;

            
        }
    }
}

