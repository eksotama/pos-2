using SQLite;

namespace pos
{
    public class Sell : Model<Sell>
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Client_Id { get; set; }

        public int Product_Id { get; set; }

        public int Amount { get; set; }

        public float Total { get; set; }
    }
}
