using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpModels
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly List<Product> _products;

        public ShoppingCart() => _products = new();
        

        public Task AddProduct(Product product)
        {
            lock (_products)
            {
                _products.Add(product);
            }
            return Task.CompletedTask;
        }

        public IReadOnlyList<Product> GetProducts() => _products;

        public Task DeleteProduct(Product product)
        {
            lock (_products)
            {
                _products.Remove(product);
            }
            return Task.CompletedTask;
        }

        public Task DeleteProduct(Guid productId)
        {
            lock (_products)
            {
                _products.Remove(_products.Single(p => p.Id == productId));
            }
            return Task.CompletedTask;
        }

        public Task Clear()
        {
            lock (_products)
            {
                _products.Clear();
            }
            return Task.CompletedTask;
        }
    }
}
