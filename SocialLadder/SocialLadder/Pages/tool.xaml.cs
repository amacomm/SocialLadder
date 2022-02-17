using SocialLadder.Styles;
using SocialLadder.TranslResours;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SocialLadder.App;

namespace SocialLadder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class tool : ContentPage
    {
        public tool()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); // скрытие NavigationBar
            Set.Text = Resource.setting;
            //Lang.Text = Resource.lenguage;
            //ThemB.Text = Resource.theme;
            Develop.Text = Resource.developers;
        }

        private async void Setting(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new satting());
        }

        /* private async void Them(object sender, EventArgs e)
         {
             string result = await DisplayActionSheet("Theme", "Cancel", null, "light", "Dark");
             ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
             if (mergedDictionaries != null)
             {
                 mergedDictionaries.Clear();

                switch (result)
                 {
                     case ("Dark"):
                         mergedDictionaries.Add(new DarkTheme());

                         break;
                     case ("light"):
                     default:
                         mergedDictionaries.Add(new LightTheme());
                         break;
                 }
              }


             Theme themeRequested = App.AppTheme == Theme.Light ? Theme.Dark : Theme.Light;
             MessagingCenter.Send<Page, Theme>(this, "ModeChanged", themeRequested);
    }*/

        /*protected override void OnAppearing()
            {
                base.OnAppearing();
            }*/

        private async void Dev(object sender, EventArgs e) // кнопка показа списка разработчиков
        {
            string result = await DisplayActionSheet(Resource.developers, "", null, "Georgy Motz", "Serik Maratov", "Malinin Igor", "Alexander Tsyganov");

            switch (result)
            {
                case ("Georgy Motz"):
                    break;
                case ("Serik Maratov"):
                    break;
                case ("Malinin Igor"):
                    break;
                case ("中文"):
                    break;
                case ("Alexander Tsyganov"):
                    break;
            }
        }
    }
}