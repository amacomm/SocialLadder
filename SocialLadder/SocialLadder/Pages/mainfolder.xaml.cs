using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace SocialLadder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mainfolder : Xamarin.Forms.TabbedPage
    {
        public Mainfolder()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            On<Android>().SetToolbarPlacement(value: ToolbarPlacement.Bottom); // функция устанавливает вкладки снизу в Android
        }

    }
}