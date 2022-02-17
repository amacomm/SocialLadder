using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net;
using System.Net.Mail;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using SocialLadder.TranslResours;

namespace SocialLadder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registration : ContentPage
    {byte[] newAva;
        public registration()
        {
            InitializeComponent();
            start.Text = Resource.Start;
            Name.Placeholder = Resource.name;
            Age.Placeholder = Resource.age;
            Country.Placeholder = Resource.country;
            Password.Placeholder = Resource.Password;
            About.Placeholder = Resource.About;
            reg.Text = Resource.registr;
            ava.Text = Resource.Photo;
            Inf.Text = Resource.InfReg;
            
        }

        public async void ClickAva(object sender, EventArgs e) // Загрузка картинки из устройства
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync(); // запись изображения в поток
            if (stream != null)
            {
                newAva = ImageByte.GetImageBytes(stream); // запись данных в массив байтов для долнейшей записи в даные пользователя
            }

                (sender as Button).IsEnabled = true;
            Inf.Text = Resource.PhotoUp;
        }

        
        private async void Registry(object sender, EventArgs e) // Проверка введённой почты и сохранение данных о клиенте на сервер
        {
            bool check_mail = true;
            string to = "";
            while (check_mail)
            {
                to = Email.Text;
                if (RegexUtilities.IsValidEmail(to))
                    check_mail = !check_mail;
                else
                    await DisplayAlert("", Resource.EmailValid, "OK");
            }
            MailMessage m = new MailMessage(new MailAddress("m4ratov.serik@yandex.ru", "MainProgerOurTeam"), new MailAddress(to));
            m.Subject = "Verification code for registration";
            Random rand = new Random();
            int Code = rand.Next(100000, 1000000);
            m.Body = "To confirm registration in the application, enter the following 6-digit code: " + Code.ToString();
            m.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25)
            {
                Credentials = new NetworkCredential("m4ratov.serik", "bn8-MvU-XiS-HLp"),
                EnableSsl = true
            };

            smtp.Send(m);
            smtp.Dispose();
            while (true)
            {
                string newpassword = await DisplayPromptAsync("Code", Resource.Code);
                if (newpassword == Code.ToString())
                {
                    await DisplayAlert("", Resource.Success, "OK");
                    break;
                }
            }
            var client = new Client(Name.Text, About.Text, Age.Text, Country.Text, Email.Text, Password.Text, newAva); //создание нового пользователя с соответствующими данными
            if (!String.IsNullOrEmpty(client.Email))
            {
                DB_tables.Database.InsertItem(client);
            }
            await this.Navigation.PopAsync();
        }
    }

    public class RegexUtilities // класс проверки строки на почту
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}