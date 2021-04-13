namespace CsharpMorningChallenge1.Models
{
    public class Product
    {
        internal int id;
        internal string productId;

        public Product(string name, string description, int price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public Product()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int Id { get; private set; }
    }
}