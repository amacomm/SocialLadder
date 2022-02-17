using SocialLadder.TranslResours;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialLadder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class rating : ContentPage
    {
        public rating()
        {

            InitializeComponent();
            Global.Text = Resource.global;
            //Your.Text = Resource.rating;
            List<Client> list = new List<Client>(DB_tables.Database.GetItems());//accumulating rating number
            list.Sort(user.CompareClientsByTotals);

            int i = 0;
            foreach (Client cl in list) // создание плашек пользователей имеющихся в БД
            {
                //      Далее происходит создание Frame элемента                //
                //      с последующим разбиением его на секции (grid)           //
                //      в каждую из которых записывается информация о           //
                //пользователе: рейтинг, фото, имя, колличество звезд и страна  //


                Frame frame = new Frame
                {
                    HasShadow = false,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    CornerRadius = 90,
                    BackgroundColor = Color.FromHex(StarValueCl.Hex(i)),
                    Margin = new Thickness(0, 2.5)
                };
                G1.Children.Add(frame, 0, 3 + i);
                Grid grid = new Grid();
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (sender, e) =>
                {
                    if (cl.Id != userpage.currClient.Id) Navigation.PushAsync(new usersearch(cl.Id));
                    
                };
                frame.GestureRecognizers.Add(tapGestureRecognizer);
                frame.Content = grid;

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(25) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(125) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                var Rating = new Label { Text = (i + 1).ToString(), TextColor = Color.White, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
                var Profil = new ImageCircle.Forms.Plugin.Abstractions.CircleImage { Source = ImageByte.BytesToImage(cl.Photo), HeightRequest = 55, VerticalOptions = LayoutOptions.Center };
                var Name = new Label { Text = cl.Name, TextColor = Color.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
                var Stars = new Label { Text = StarValueCl.StarValue(cl.Total), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
                var Country = new Label { Text = cl.Country, TextColor = Color.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };

                grid.Children.Add(Rating, 0, 0);
                grid.Children.Add(Profil, 1, 0);
                grid.Children.Add(Name, 2, 0);
                grid.Children.Add(Stars, 3, 0);
                grid.Children.Add(Country, 4, 0);
                ++i;
            }
        }

    }
}