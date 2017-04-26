using Xamarin.Forms.Platform.Android.AppCompat;
using System.Reflection;
using Xamarin.Forms;
using MyApps.Droid;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(CustomMasterDetailRenderer))]
namespace MyApps.Droid
{

    public class CustomMasterDetailRenderer : MasterDetailPageRenderer
    {
        public override void AddView(Android.Views.View child)
        {
            child.GetType().GetRuntimeProperty("TopPadding").SetValue(child, 0);
            var padding = child.GetType().GetRuntimeProperty("TopPadding").GetValue(child);

            base.AddView(child);
        }
    }
}