using SQLite;

namespace Shopper.Models

{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Bought { get; set; }
    }
}

