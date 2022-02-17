using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialLadder
{
    public partial class App : Application
    {
        public static Theme AppTheme { get; set; }
        public App()
        {
            NavigationPage.SetHasNavigationBar(this, false); // скрытие NavigationBar
            InitializeComponent();
            //DB_tables.Database.DeleteItem(0); // Очищение базы данных
            MainPage = new NavigationPage(new userpage()); // Запуск формы входа
        }

        public enum Theme { Light, Dark }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
