using MyApps.ViewsModel;
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
    public partial class MapPage : ContentPage
    {
        
        public MapPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        Position MyPosition = new Position(36.244998, 6.570788);
        protected override async  void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var pos = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(MyPosition, Distance.FromKilometers(1)));

            List<Restaurant> restaurants = Restaurants.Restaurant;
            
            foreach (Restaurant r in restaurants)
            {
                
                
                     var pin = new Pin
                     {
                        
                        Position = new Position(r.address.Latitude, r.address.Longitude),
                        Label = r.description != null ? r.description : "No description !!!",
                        
                        
                    };
                    pin.Clicked += PinOnClicked;

                    MainMap.Pins.Add(pin);
                    
                
            }
            
            
        }
        private void PinOnClicked(object sender, EventArgs e)
        {
            var selectedPin = sender as Pin;
            DisplayAlert(selectedPin?.Label, selectedPin?.Address, "OK");
        }
        
        //private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        //{
            
        //    double theta = 6.570788 - restaurant.Longitude ;
        //    double dist = Math.Sin(deg2rad(36.244998)) * Math.Sin(deg2rad(restaurant.Latitude)) + Math.Cos(deg2rad(36.244998)) * Math.Cos(deg2rad(restaurant.Latitude)) * Math.Cos(deg2rad(theta));
        //    dist = Math.Acos(dist);
        //    dist = rad2deg(dist);
        //    dist = dist * 60 * 1.1515;
        //    if (unit == 'K')
        //    {
        //        dist = dist * 1.609344;
        //    }
        //    else if (unit == 'N')
        //    {
        //        dist = dist * 0.8684;
        //    }
        //    return (dist);
        //}
        //private double deg2rad(double deg)
        //{
        //    return (deg * Math.PI / 180.0);
        //}
        //private double rad2deg(double rad)
        //{
        //    return (rad / Math.PI * 180.0);
        //}
    }
}
