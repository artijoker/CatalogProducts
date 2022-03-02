using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpModels
{
    public interface IShoppingCart
    {
        Task AddProduct(Product product);
        IReadOnlyList<Product> GetProducts();
        Task DeleteProduct(Product product);
        Task DeleteProduct(Guid productId);
        Task Clear();
    }
}
