

using MyApps.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastAndroid))]
namespace MyApps.Droid
{

    public class ToastAndroid : Toast
    {
        public void Show(string Message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, Message, Android.Widget.ToastLength.Long).Show();
        }
    }
}