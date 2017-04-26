using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace MyApps.Views
{

    public partial class Offre : ContentPage
    {
        
        public Offre()
        {
            
            InitializeComponent();
            
            RestaurantListView.ItemSelected += async (sender, e) =>
            {
                Restaurant rest = e.SelectedItem as Restaurant;
                if (e.SelectedItem != null)
                {
                    
                   await Navigation.PushAsync(new DetailPage(rest));
              
                }
                    RestaurantListView.SelectedItem = null;
            };
            tapImage.Tapped += async (object sender, EventArgs e) =>
            {
                      await Navigation.PushAsync(new MapPage());
            };
        }
        protected override async void OnAppearing()
        {
            
            await GetRestaurant();
            



        }
        
        List<Restaurant> getListFromJson(String json)
        {
            var Restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);


            return Restaurants;
        }

        public static List<Restaurant> Restaurants;
        public async Task GetRestaurant()
        {

            var client = new HttpClient();


            var json = await client.GetStringAsync("http://192.168.0.111:55469/api/plates");
            Restaurants = getListFromJson(json);
            RestaurantListView.ItemsSource = Restaurants;

            
        }
    }
}
