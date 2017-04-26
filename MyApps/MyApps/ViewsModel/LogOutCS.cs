using MyApps.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApps
{
    public class LogOutCS : ContentPage
    {
        public LogOutCS()
        {
            App.IsUserLoggedIn = false;
            Navigation.PushAsync(new LoginPageCS());
            Navigation.PopAsync();


        }

        
    }
}
