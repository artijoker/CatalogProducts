namespace HttpModels
{
    public class ProductModel
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? UrlImage { get; set; }
    }
}
