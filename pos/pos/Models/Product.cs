using SQLite;

namespace pos
{
    public class Product : Model<Product>
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Photo_Url { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Cost { get; set; }
    }
}
