using System.Collections.Generic;
using SQLite;

namespace SocialLadder
{
    public class ClientRepository
    {
        SQLiteConnection database;
        public ClientRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Client>();
        }
        public IEnumerable<Client> GetItems()
        {
            return database.Table<Client>().ToList();   //возвращает все объекты из таблицы
        }
        public Client GetItem(int id)
        {
            return database.Get<Client>(id); //позволяет получить элемент типа Client по id
        }
        public int DeleteItem(int id)
        {
            return database.DeleteAll<Client>(); //удаляет объект по id
        }

        public void InsertItem(Client item)
        {
            database.Insert(item);
        }

        public void UpdateItem(Client item)
        {
            database.Update(item);  //обновляет объект
        }
    }
}
