using SQLite;

namespace pos
{
    public class Client : Model<Client>
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Profile_Url { get; set; }

        public string Phone { get; set; }      
    }
}
