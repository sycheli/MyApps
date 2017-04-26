using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

namespace MyApps.Droid
{
    [Activity(Label = "MyApps", Icon = "@drawable/logo", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
          
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            Forms.SetTitleBarVisibility(AndroidTitleBarVisibility.Never);
            LoadApplication(new App());
        }
        
    }
}

