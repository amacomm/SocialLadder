using SQLite;
using System;
using System.Collections.Generic;
using System.Dynamic;
using Xamarin.Forms;

namespace SocialLadder
{
    [Table("Clients")]
    // Класс клиентов приложения 
    public class Client
    {
        public Client()
        { }
        public Client(string Name, string About, string Age, string Country, string Email, string Password, byte[] Ava)
        {
            this.Name = Name;
            this.About = About;
            this.Age = Convert.ToInt32(Age);
            this.Country = Country;
            this.Email = Email;
            this.Password = Password;
            this.Beauty = 50;
            this.Charisma = 50;
            this.Senseofhumor = 50;
            this.Intelligence = 50;
            this.Conversation = 50;
            this.Activity = 50;
            this.Responsibility = 50;
            this.Strength = 50;
            this.Photo = Ava;
        }

        public static Client GetClient(int Id)
        {
            IEnumerable<Client> list = DB_tables.Database.GetItems();
            foreach (Client cl in list)
                if (Id == cl.Id)
                    return cl;

            return new Client();
        }

        public Client ChangeChars(int ch, int br, int fr, int ac, int di, int tr, int be, int str)
        {
            this.Beauty = (this.Beauty * 9 + ch) / 10;
            this.Charisma = (this.Charisma * 9 + br) / 10;
            this.Senseofhumor = (this.Senseofhumor * 9 + fr) / 10;
            this.Intelligence = (this.Intelligence * 9 + ac) / 10;
            this.Conversation = (this.Conversation * 9 + di) / 10;
            this.Activity = (this.Activity * 9 + di) / 10;
            this.Responsibility = (this.Responsibility * 9 + be) / 10;
            this.Strength = (this.Strength * 9 + str) / 10;
            this.Total = (Beauty + Charisma + Senseofhumor + Intelligence + Conversation + Activity + Responsibility + Strength) / 80;
            return this;
        }

        [PrimaryKey, AutoIncrement,Unique, Column("_id")]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        [Unique]
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }//Георгий сделал текстбокс
        public byte[] Photo { get; set; }

        /*Тут начинается вся пое**та с баллами*/
        public int Beauty { get; set; }
        public int Charisma { get; set; }
        public int Senseofhumor { get; set; }
        public int Intelligence { get; set; }
        public int Conversation { get; set; }
        public int Activity { get; set; }
        public int Responsibility { get; set; }
        public int Strength { get; set; }
        public int Total 
        { 
            get
            { 
                return (Beauty + Charisma + Senseofhumor + Intelligence + Conversation + Activity + Responsibility + Strength) / 8; 
            }
            set
            { } 
        }
    }
}
