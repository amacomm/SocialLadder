using SocialLadder.TranslResours;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialLadder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class usersearch : ContentPage
    {
       Client User;
        public usersearch(int Id)
        {
            InitializeComponent();

            User = Client.GetClient(Id);
            prog.ProgressTo((double)User.Total / 100, 3500, Easing.Linear);
            Names.Text = User.Name;
            About.Text = User.About;
            Country.Text = User.Country;
            Rating.Text = (user.GetClientNumberPos(User.Id) + 1).ToString();
            Star.Text = StarValueCl.StarValue(User.Total);
            Profil.Source = ImageSource.FromStream(() => new MemoryStream(User.Photo));
            CountryT.Text = Resource.country;
            RatingT.Text = Resource.rating;
            StarT.Text = Resource.star;
            charism.ProgressTo((double)User.Beauty / 100, 3500, Easing.Linear);
            brean.ProgressTo((double)User.Charisma / 100, 3500, Easing.Linear);
            friandly.ProgressTo((double)User.Senseofhumor / 100, 3500, Easing.Linear);
            activ.ProgressTo((double)User.Intelligence / 100, 3500, Easing.Linear);
            dialog.ProgressTo((double)User.Conversation / 100, 3500, Easing.Linear);
            trust.ProgressTo((double)User.Activity / 100, 3500, Easing.Linear);
            beauty.ProgressTo((double)User.Responsibility / 100, 3500, Easing.Linear);
            strong.ProgressTo((double)User.Strength / 100, 3500, Easing.Linear);
        }

        private async void SetRating(object sender, EventArgs e) // открытие формы смены рейтинга при нажатии кнопки
        {
            await Navigation.PushAsync(new ratingchange(User.Id, Names.Text, User.Beauty, User.Charisma, User.Senseofhumor, User.Intelligence,
                User.Conversation, User.Activity, User.Responsibility, User.Strength));
            
        }
        private async void Subscribe(object sender, EventArgs e)
        {
            //userpage.currClient.Subscribers.Add(User);
            await DisplayAlert(Resource.Alert, "You have been subscribed  to this user", "OK");
            return;

        }
    }
}