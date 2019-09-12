using System.Collections.Generic;
using SQLite;

namespace pos
{
    public class Client
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Profile_Url { get; set; }

        public string Phone { get; set; }


        public Client() {}

        public Client(string name, string address, string email, string profileUrl, string phone)
        {
            Name = name;
            Address = address;
            Email = email;
            Profile_Url = profileUrl;
            Phone = phone;
        }

        public static void Add(Client client)
        {
            var db = PosDb.Connect();
            db.Insert(client);
            db.Close();
        }

        public static Client Get(string id)
        {
            var db = PosDb.Connect();
            var users = db.Query<Client>("SELECT * WHERE Id = ?", id);
            db.Close();
            return users[0];
        }

        public static void Update(Client client)
        {
            var db = PosDb.Connect();
            db.Update(client);
            db.Close();
        }

        public static void Delete(Client client)
        {
            var db = PosDb.Connect();
            db.Delete(client);
            db.Close();
        }

        public static List<Client> Get_All()
        {
            var db = PosDb.Connect();
            var users = db.Table<Client>().ToList();
            db.Close();
            return users;
        }
    }
}
