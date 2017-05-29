using MyApps.ViewsModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyApps
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }
        public void OnLogin(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new SideDrawer())
            {
                BarBackgroundColor = Color.FromHex("#00B0CD"),
                BarTextColor = Color.White,
            };
        }
    }
}
