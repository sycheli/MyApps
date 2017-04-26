using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyApps.Views
{
    public partial class MapPages : ContentPage
    {

       
        public MapPages()
        {

            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        protected override  void OnAppearing()
        {           
            base.OnAppearing();
            List<Restaurant> restaurants = DetailPage.Restaurants;
            foreach (Restaurant r in restaurants)
            {
                
                if (r.Longitude != null && r.Latitude != null) {
                     var pin = new Pin
                     {
                        
                        Position = new Position(r.Latitude, r.Longitude),
                        Label = r.description != null ? r.description : "No description !!!",
                        Address = r.Addresses != null ? r.Addresses : "No address !!!",
                        
                    };
                    pin.Clicked += PinOnClicked;

                    MainMap.Pins.Add(pin);
                    
                }
            }
            
            
        }
        private void PinOnClicked(object sender, EventArgs e)
        {
            var selectedPin = sender as Pin;
            DisplayAlert(selectedPin?.Label, selectedPin?.Address, "OK");
        }
        
        
           
    }
}
