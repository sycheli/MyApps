using MyApps.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyApps
{
    public partial class DetailPage : ContentPage
    {

       Restaurant restaurant;

        public DetailPage(Restaurant restaurant)
        {

            this.restaurant = restaurant;
          
            InitializeComponent();
           
            
                        
        }
        public static List<Restaurant> Restaurants;
        protected override  void OnAppearing()
        {
           
            base.OnAppearing();
            var restaurants = new List<Restaurant>();
            restaurants.Add(restaurant);
            name.Text = restaurant.name;
            description.Text = restaurant.description;
            image.Source = restaurant.img;



        }
        
         protected void Allerà(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new MapPages(restaurant));
        }


    }
}
