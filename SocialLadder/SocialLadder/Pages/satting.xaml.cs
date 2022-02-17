using SocialLadder.TranslResours;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialLadder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class satting : ContentPage
    {
        public satting()
        {
            InitializeComponent();
            Pass.Text = Resource.chpass;
            pass1.Placeholder = Resource.newpass;
            pass2.Placeholder = Resource.rnewpass;
            ChPass.Text = Resource.chpass;
            MailL.Text = Resource.chmail;
            maile.Placeholder = Resource.newmail;
            Bmail.Text = Resource.chmail;
            CAva.Text = Resource.chava;
            LAva.Text = Resource.lodnava;
            about.Placeholder = Resource.About;
            Chabout.Text = Resource.Chabout;
        }

        private async void pass(object sender, EventArgs e) // кнопка смены пароля
        {
            if (pass1.Text == pass2.Text && pass1.Text != userpage.currClient.Password && pass1.Text != null)
            {
                userpage.currClient.Password = pass1.Text; // запись данных в соответствуюющее поле
                DB_tables.Database.UpdateItem(userpage.currClient);// обновление элементов пользователя
                await DisplayAlert(Resource.PassHasChang, "", "Ok"); // вывод сообщения об успешной смене данных
            }
            else Error();
        }


        private async void mail(object sender, EventArgs e) // кнопка смены почты
        {
            if (maile.Text != userpage.currClient.Email && maile.Text != null)
            {
                IEnumerable<Client> list = DB_tables.Database.GetItems(); //загрузка пользователей из БД
                foreach (Client cl in list) // Проверка на уникальность новой почты
                {
                    if (cl.Email == maile.Text)
                        Errore();
                    else
                        continue;
                }
                userpage.currClient.Email = maile.Text; // запись данных в соответствуюющее поле
                DB_tables.Database.UpdateItem(userpage.currClient); // обновление элементов пользователя
                await DisplayAlert(Resource.MailhasChang, "", "Ok"); // вывод сообщения об успешной смене данных
            }
            else Errore();
        }

        private async void Error() // всплывающее окно ошибки ввода пароля
        {
            await DisplayAlert(Resource.Error, Resource.PassDM, "Ok");
        }

        private async void Errore() // всплывающее окно ошибки ввода почты
        {
            await DisplayAlert(Resource.Error, Resource.MailIsUsed, "Ok");
        }

        public async void ChengeAva(object sender, EventArgs e) // кнопка смены фотографии пользователя
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync(); // запись изображения в поток
            if (stream != null)
            {
                userpage.currClient.Photo = ImageByte.GetImageBytes(stream); // запись данных в соответствуюющее поле
            }

                (sender as Button).IsEnabled = true;
            DB_tables.Database.UpdateItem(userpage.currClient);// обновление элементов пользователя
        }

        private void ClickAbout(object sender, EventArgs e) // кнопка смены информации о пользователе
        {
            userpage.currClient.About = about.Text; // запись данных в соответствуюющее поле
            DB_tables.Database.UpdateItem(userpage.currClient); // обновление элементов пользователя
        }
    }
}