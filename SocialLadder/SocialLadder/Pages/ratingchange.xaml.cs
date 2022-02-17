using SocialLadder.TranslResours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialLadder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ratingchange : ContentPage
    {
        public int ch = 50, br = 50, fr = 50, ac = 50, di = 50, tr = 50, be = 50, str = 50;
        new int Id;
        public ratingchange(int Idc, string Names, int ch1, int br1, int fr1, int ac1, int di1, int tr1, int be1, int str1)
        {
            InitializeComponent();
            Id = Idc;
            ch = ch1;
            br = br1;
            fr = fr1;
            ac = ac1;
            di = di1;
            tr = tr1;
            be = be1;
            str = str1;
            Ncharism.Text = String.Format("{0}", ch / 10);
            Nbrean.Text = String.Format("{0}", br / 10);
            Nfriandly.Text = String.Format("{0}", fr / 10);
            Nactiv.Text = String.Format("{0}", ac / 10);
            Ndialog.Text = String.Format("{0}", di / 10);
            Ntrust.Text = String.Format("{0}", tr / 10);
            Nbeauty.Text = String.Format("{0}", be / 10);
            Nstrong.Text = String.Format("{0}", str / 10);
            MLable.Text = Resource.Ratingfor+ " " + Names;
        }

        //                                                      //
        // Функции реагирующие на изменение значения слайдеров  //
        //                                                      //

        void Beauty(object sender, ValueChangedEventArgs args)
        {
            int value = Convert.ToInt32(args.NewValue);
            Ncharism.Text = String.Format("{0}",(int)(value/10));
            ch = value;
        }

        void Charism(object sender, ValueChangedEventArgs args)
        {
            int value = Convert.ToInt32(args.NewValue);
            Nbrean.Text = String.Format("{0}", (int)(value / 10));
            br = value;
        }
        void Senseofhumor(object sender, ValueChangedEventArgs args)
        {
            int value = Convert.ToInt32(args.NewValue);
            Nfriandly.Text = String.Format("{0}", (int)(value / 10));
            fr = value;
        }
        void Intelligence(object sender, ValueChangedEventArgs args)
        {
            int value = Convert.ToInt32(args.NewValue);
            Nactiv.Text = String.Format("{0}", (int)(value / 10));
            ac = value;
        }
        void Conversation(object sender, ValueChangedEventArgs args)
        {
            int value = Convert.ToInt32(args.NewValue);
            Ndialog.Text = String.Format("{0}", (int)(value / 10));
            di = value;
        }
        void Activity(object sender, ValueChangedEventArgs args)
        {
            int value = Convert.ToInt32(args.NewValue);
            Ntrust.Text = String.Format("{0}", (int)(value / 10));
            tr = value;
        }
        void Responsibility(object sender, ValueChangedEventArgs args)
        {
            int value = Convert.ToInt32(args.NewValue);
            Nbeauty.Text = String.Format("{0}", (int)(value / 10));
            be = value;
        }
        void Strength(object sender, ValueChangedEventArgs args)
        {
            int value = Convert.ToInt32(args.NewValue);
            Nstrong.Text = String.Format("{0}", (int)(value / 10));
            str = value;
        }

        public void Set(object sender, EventArgs e) // кнопка обновления рейтинга
        {
            //Отправка в базу
            Client curr = Client.GetClient(Id);
            curr.ChangeChars(ch, br, fr, ac, di, tr, be, str);
            string sTotal = curr.Total.ToString();

            if (!String.IsNullOrEmpty(sTotal))
            {
                DB_tables.Database.UpdateItem(curr);
            }
            this.Navigation.PopAsync();
        }
    }
}