using MyApps.Views;
using MyApps.ViewsModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyApps
{
    public partial class DetailPage : ContentPage
    {
        
        Offres Ofrre;
        string stringVal;
        string stringVal1;
        
        public DetailPage(Offres Ofrre)
        {
            Title = Ofrre.name;
            this.Ofrre = Ofrre;
          
            InitializeComponent();
           
            
                        
        }
        public static List<Offres> Offre;
        public static List<Restaurant> restaurant;
        protected override  void OnAppearing()
        {
           
            base.OnAppearing();
            var Offre = new List<Offres>();
            
            Offre.Add(Ofrre);
            
            name.Text = Ofrre.name;
            description.Text = Ofrre.description;
            image.Source = Ofrre.img;
            stringVal = System.Convert.ToString(Ofrre.price);
            price.Text = stringVal;
            stringVal1 = System.Convert.ToString(Ofrre.rate);
            rate.Text = stringVal1;
            

        }
        
         


    }
}
