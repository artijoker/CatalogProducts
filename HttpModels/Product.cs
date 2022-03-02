namespace HttpModels
{
    public class Product
    {
        public Guid Id { get; }
        public string Name { get; }
        public Category Category { get; }
        public decimal Price { get; }
        public int Quantity { get; }
        public string? UrlImage { get; }

        public Product(string name, Category category, decimal price, int quantity, string? urlImage = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
            UrlImage = urlImage;
        }
        public Product(Guid id, string name, Category category, decimal price, int quantity, string? urlImage = null)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
            UrlImage = urlImage;
        }
    }
}