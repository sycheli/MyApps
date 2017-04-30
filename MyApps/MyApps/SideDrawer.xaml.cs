using MyApps;
using MyApps.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyApps
{
    public partial class SideDrawer : MasterDetailPage
    {
        List<MasterPageItem> menuList { get; set; }
        
        public SideDrawer()
        {

            NavigationPage.SetHasNavigationBar(this,false);
            InitializeComponent();
            menuList = new List<MasterPageItem>();

            var page1 = new MasterPageItem() { Title = "Offre", Icon = "Offre.png", TargetType = typeof(Offre) };
            var page2 = new MasterPageItem() { Title = "Restaurants", Icon = "Restaurant.png", TargetType = typeof(Restaurants) };
            var page3 = new MasterPageItem() { Title = "Mes Commandes", Icon = "Commande.png", TargetType = typeof(Commandes) };
            var page4 = new MasterPageItem() { Title = "Mes Points Bonus", Icon = "bonus.png", TargetType = typeof(Points) };
            var page5 = new MasterPageItem() { Title = "Paramètres", Icon = "Setting.png", TargetType = typeof(Paramètres) };
   
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
 
            navigationDrawerList.ItemsSource = menuList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(NavPage)))
            {
                BarBackgroundColor = Color.FromHex("#00B0CD"),
                BarTextColor=Color.White,
            };

            Logout.Tapped += (object sender, EventArgs e) =>
            {
                App.IsUserLoggedIn = false;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            };
        }

         
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
            var item = (MasterPageItem)e.SelectedItem;           
            Type page = item.TargetType;
            Navigation.PushAsync((Page)Activator.CreateInstance(page));
             IsPresented = false;
           
        }
    }
}
