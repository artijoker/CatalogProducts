using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpModels
{
    public class InMemoryCatalog : ICatalog
    {
        private readonly List<Category> _categories;
        private readonly List<Product> _products;

        public InMemoryCatalog()
        {
            _categories = new();
            _products = new();
        }


        public InMemoryCatalog(ICollection<Product> products, ICollection<Category> categories)
        {
            _categories = categories.ToList();
            _products = products.ToList();
        }

        public IReadOnlyList<Product> GetProducts(string userAgent, Guid? categoryId = null, DateTime? date = null)
        {
            IEnumerable<Product> products;
            decimal percent = GetPercent(userAgent.ToLower(), date);
            lock (_products)
            {
                products = _products.Select(
                    p => new Product(
                        p.Id,
                        p.Name,
                        p.Category,
                        p.Price + (percent == 0 ? 0 : (p.Price / 100) * percent),
                        p.Quantity,
                        p.UrlImage
                        )
                );
                if (categoryId is not null)
                    products = products.Where(p => p.Category.Id == categoryId);
            }
            return products.ToList();
        }

        public Product GetProductById(Guid id)
        {
            Product product;
            lock (_products)
            {
                product = _products.Where(p => p.Id == id).Single();
            }
            return product;
        }

        public Category GetCategoryById(Guid id)
        {
            Category category;
            lock (_categories)
            {
                category = _categories.Where(c => c.Id == id).Single();
            }
            return category;
        }

        public void AddProduct(Product product)
        {
            lock (_products)
            {
                _products.Add(product);
            }
        }

        public void AddCategorie(Category category)
        {
            lock (_categories)
            {
                _categories.Add(category);
            }
        }

        public bool IsNewCategoryId(Guid id) => !_categories.Any(c => c.Id == id);

        public IReadOnlyList<Category> GetCategories() => _categories;

        private static int GetPercent(string userAgent, DateTime? date = null)
        {
            DateTime dateTime = date ?? DateTime.Now;
            int percent = 0;
            percent -= dateTime.DayOfWeek == DayOfWeek.Wednesday ? 50 : 0;
            percent += dateTime.DayOfWeek == DayOfWeek.Friday ? 50 : 0;
            percent -= userAgent.Contains("android") ? 10 : 0;
            percent += userAgent.Contains("iphone") || userAgent.Contains("ipad") ? 50 : 0;
            return percent;
        }

        public static InMemoryCatalog MakeTestCatalog()
        {
            List<Product> products = new();
            List<Category> categories = new();

            categories.Add(new("Смарфоны"));
            products.Add(new(
                Guid.Parse("6a5842ee-72e8-4cfe-9ca8-b5b22d53da60"),
                "Смартфон Google Pixel 5a",
                categories[^1],
                560m,
                20,
                "https://cdn1.ozone.ru/s3/multimedia-3/wc250/6237328203.jpg")
                );

            categories.Add(new("USB накопители"));
            products.Add(new(
                Guid.Parse("3cfb8124-d6a5-41fd-8f41-b7a4479c09b9"),
                "USB накопитель Samsung",
                categories[^1],
                30m,
                35,
                "https://cdn1.ozone.ru/multimedia/wc1200/1026248251.jpg")
                );

            categories.Add(new("Ноутбуки"));
            products.Add(new(
                Guid.Parse("d7c046f7-96e7-4cfb-9a80-e045fc0b597d"), 
                "Ноутбук Lenovo IdeaPad 4 15IX5P6", 
                categories[^1], 
                830.50m, 
                15, 
                "https://cdn1.ozone.ru/s3/multimedia-7/wc1200/6166994971.jpg")
                );

            categories.Add(new("Наушники"));
            products.Add(new(
                Guid.Parse("f540b8d6-bdef-47f4-ad16-6b497ff99382"), 
                "Наушники Sony WH-CH56030NW", 
                categories[^1], 
                130.60m, 
                25, 
                "https://cdn1.ozone.ru/s3/multimedia-r/wc1200/6179635779.jpg")
                );

            categories.Add(new("Игровые консоли"));
            products.Add(new(
                Guid.Parse("527f3d0c-55d8-4e6b-ab4d-ed5cab193413"), 
                "Microsoft Xbox Series X", 
                categories[^1], 
                985m, 
                2, 
                "https://cdn1.ozone.ru/s3/multimedia-l/wc1200/6232471137.jpg")
                );

            categories.Add(new("Телевизоры"));
            products.Add(new(
                Guid.Parse("25a33e15-dcce-482f-b50e-204908370a8d"),
                "Телевизор Sony KD50X81J 50", 
                categories[^1], 
                1000.89m, 
                15, 
                "https://cdn1.ozone.ru/s3/multimedia-n/wc1200/6068732087.jpg")
                );

            return new InMemoryCatalog(products, categories);
        }
    }
}