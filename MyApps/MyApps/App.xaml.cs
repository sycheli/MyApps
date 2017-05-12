
using MyApps.Views;
using MyApps.ViewsModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApps
{
    public partial class App : Application
    {
        
        public static bool IsUserLoggedIn { get; set; }
        public App()
        {
            MainPage = new NavigationPage(new SideDrawer());




            //if (!IsUserLoggedIn)
            //{
            //    MainPage = new NavigationPage(new ViewPage());
            //}
            //else
            //{

            //    MainPage = new NavigationPage(new SideDrawer())
            //    {
            //        BarBackgroundColor = Color.FromHex("#00B0CD"),
            //        BarTextColor = Color.White,
            //    };
            //}
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
