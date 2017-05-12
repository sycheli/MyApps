using MyApps.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyApps
{
    public partial class RestaurantDetails : ContentPage
    {
        string stringVal;
        Restaurant restaurant;

        public RestaurantDetails(Restaurant restaurant)
        {
            Title = restaurant.name;
            this.restaurant = restaurant;
            InitializeComponent();
           NavigationPage.SetHasNavigationBar(this, false);
            //tapAdress.Tapped += async (object sender, EventArgs e) =>
            //{
            //    await Navigation.PushAsync(new MapPage());
            //};
        }

        public static List<Restaurant> Restaurants;
        protected override void OnAppearing()
        {

            base.OnAppearing();
            var restaurants = new List<Restaurant>();
            restaurants.Add(restaurant);
            name.Text = restaurant.name;
            image.Source = restaurant.cover;
            street.Text = restaurant.address.street;
            city.Text = restaurant.address.city;
            country.Text = restaurant.address.country;
            stringVal = System.Convert.ToString(restaurant.address.zipCode);
            zipCode.Text = stringVal;



        }
    }
}
