using System;
using Xamarin.Forms;
using System.IO;

namespace SocialLadder
{
    public partial class DB_tables : ContentView
    {
        public DB_tables()
        {
            InitializeComponent();
        }

        public const string DATABASE_NAME = "ClientsTables.db";  // файл хранения таблицы клиентов
        public static ClientRepository database;
        public static ClientRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new ClientRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
    }
}