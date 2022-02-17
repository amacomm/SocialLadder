using Rg.Plugins.Popup.Services;
using SocialLadder.TranslResours;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialLadder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class user : ContentPage
    {
        public static int CompareClientsByTotals(Client x, Client y)//comparison for the sort clients list
        {
            if (x.Total > y.Total)
                return -1;
            else if (x.Total < y.Total)
                return 1;
            else
                return 0;
        }

        public static int GetClientNumberPos(int id)
        {
            List<Client> clients = new List<Client>(DB_tables.Database.GetItems());//accumulating rating number
            clients.Sort(CompareClientsByTotals);
            int i = 0;
            foreach (Client cl in clients)
            {
                if (cl.Id == id)
                    return i;
                ++i;
            }
            return -1;
        }

        public user()
        {
            InitializeComponent();

            prog.ProgressTo((double)userpage.currClient.Total / 100, 3500, Easing.Linear);
            Names.Text = userpage.currClient.Name;
            About.Text = userpage.currClient.About;
            Country.Text = userpage.currClient.Country;
            Rating.Text = (GetClientNumberPos(userpage.currClient.Id) + 1).ToString();    //printing rating number
            Star.Text = StarValueCl.StarValue(userpage.currClient.Total);
            Profil.Source = ImageByte.BytesToImage(userpage.currClient.Photo); //photo
            CountryT.Text = Resource.country;
            RatingT.Text = Resource.rating;
            StarT.Text = Resource.star;
            charism.ProgressTo((double)userpage.currClient.Beauty / 100, 3500, Easing.Linear);
            brean.ProgressTo((double)userpage.currClient.Charisma / 100, 3500, Easing.Linear);
            friandly.ProgressTo((double)userpage.currClient.Senseofhumor / 100, 3500, Easing.Linear);
            activ.ProgressTo((double)userpage.currClient.Intelligence / 100, 3500, Easing.Linear);
            dialog.ProgressTo((double)userpage.currClient.Conversation / 100, 3500, Easing.Linear);
            trust.ProgressTo((double)userpage.currClient.Activity / 100, 3500, Easing.Linear);
            beauty.ProgressTo((double)userpage.currClient.Responsibility / 100, 3500, Easing.Linear);
            strong.ProgressTo((double)userpage.currClient.Strength / 100, 3500, Easing.Linear);
            Back.Source = "XXL";
        }

        

        private void GetGraf(object sender, EventArgs e)
        {
            //PopupNavigation.Instance.PushAsync(new PopGraf());
        }
    }
}