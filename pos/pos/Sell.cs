using SQLite;

namespace pos
{
    public class Sell : Model<Sell>
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
