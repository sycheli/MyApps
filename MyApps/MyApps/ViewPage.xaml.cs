using System;

using Xamarin.Forms;

namespace MyApps
{
    public partial class ViewPage : ContentPage
    {
        public ViewPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void Connecter(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new LoginPage());
        }
        async void Inscrire(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
