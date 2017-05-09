
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApps.Views
{
    public partial class Restaurants : ContentPage
    {
        int n = 0;
        public Restaurants()
        {
            InitializeComponent();
            RestaurantListView.ItemSelected += async (sender, e) =>
            {
                Restaurant rest = e.SelectedItem as Restaurant;
                if (e.SelectedItem != null)
                {
                    bgLayer.IsVisible = true;
                    frameLayer.IsVisible = true;
                    await Task.Delay(2000);
                    n++;
                    await Navigation.PushAsync(new NavigationPage(new RestaurantDetails(rest)));
                    frameLayer.IsVisible = false;
                    bgLayer.IsVisible = false;


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


            var json = await client.GetStringAsync("http://10.0.3.2:51868/api/restaurants");
            Restaurant = getListFromJson(json);
            RestaurantListView.ItemsSource = Restaurant;

            
        }
        private void AbsolutePageXaml_SizeChanged(object sender, EventArgs e)
        {
            AbsoluteLayout.SetLayoutFlags(frameLayer,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(frameLayer,
                new Rectangle(0.5d, 0.5d,
                Device.OnPlatform(AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize, this.Width), AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(bgLayer,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(bgLayer,
                new Rectangle(0d, 0d,
                this.Width, this.Height));


        }
    }
}

