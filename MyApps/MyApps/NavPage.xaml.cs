using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

[assembly: ComVisible(false)]
namespace MyApps
{
    [ComVisible(false)]
    public partial class NavPage : TabbedPage
    {
        public NavPage()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            
        }
    }
}
