using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace MyApps.Views
{

    public partial class Offre : ContentPage
    {
        int n = 0;
        public Offre()
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

                    await Navigation.PushAsync(new DetailPage(rest));
                    frameLayer.IsVisible = false;
                    bgLayer.IsVisible = false;
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


            var json = await client.GetStringAsync("http://10.0.3.2:55469/api/plates");
            Restaurants = getListFromJson(json);
            RestaurantListView.ItemsSource = Restaurants;

            
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
