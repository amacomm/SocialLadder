using SocialLadder.TranslResours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SocialLadder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class userpage : ContentPage
    {
        static public Client currClient = null;
        public userpage()
        {
            NavigationPage.SetHasNavigationBar(this, false); // скрытие NavigationBar
            InitializeComponent();
            pass.Placeholder = Resource.Password;
            //trouble.Text = Resource.trouble;
            Log.Text = Resource.Login;
            //OR.Text = Resource.or;
            //google.Text = Resource.google;
            SignUp.Text = Resource.regist;
        }

        private async void LoginClicked(object sender, EventArgs e) // кнопка перехода на страницу с вкладками в случае присутствия пользовтеля с соответствующими данными
        {
            IEnumerable<Client> list = DB_tables.Database.GetItems(); // загрузка пользовательской БД
            bool d = list == null;
            if (!d)
            {
                foreach (Client cl in list) // проверка на совподение почты и пароля у одного из пользователей в БД
                {
                    if (cl.Email == mail.Text && pass.Text == cl.Password)
                    {
                        currClient = cl;
                        await Navigation.PushAsync(new Mainfolder());
                        return;
                    }
                }
            }
            pass.Text = "";
            await DisplayAlert(Resource.LoginError, Resource.WrongMailPass, "OK");

        }


        private async void SignupClicked(object sender, EventArgs e) // кнопка перехода на страницу регестранции
        {
            Client client = new Client();
            registration regPage = new registration();
            regPage.BindingContext = client;
            await Navigation.PushAsync(regPage);
        }

        private async void TroubleClicked(object sender, EventArgs e)
        {
            if (mail.Text == "amacomm@mail.ru")
            {
                string result = await DisplayPromptAsync(Resource.Verify, Resource.Code);
                if (result == "1234")
                {
                    string newpassword = await DisplayPromptAsync(Resource.chpass, Resource.EnterNewPass);
                    await Navigation.PushAsync(new Mainfolder());
                }
                else await DisplayAlert(Resource.Alert, Resource.InvalidCode, "OK");
            }
            else if (mail.Text == null)
            {
                await DisplayAlert(Resource.Alert, Resource.EmailNotEnter, "OK");
            }
            else
            {
                await DisplayAlert(Resource.Alert, Resource.NotReg, "OK");
            }
        }
    }
}