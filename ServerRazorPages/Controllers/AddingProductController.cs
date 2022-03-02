using HttpModels;
using Microsoft.AspNetCore.Mvc;

namespace ServerRazorPages.Controllers
{
    public class AddingProductController : Controller
    {
        private readonly ICatalog _cataloged;

        public AddingProductController(ICatalog cataloged)
        {
            _cataloged = cataloged;
        }
        
        public IActionResult AddingProduct(ProductModel model)
        {
            (Category[], bool?) typle;
            if (HttpContext.Request.Method == "POST")
            {
                Category? category = _cataloged.GetCategoryById(model.CategoryId);
                if (category is not null)
                {
                    Product product = new(
                        model.Name,
                        category,
                        model.Price,
                        model.Quantity,
                        model.UrlImage
                        );
                    _cataloged.AddProduct(product);
                    typle = (_cataloged.GetCategories().ToArray(), true);
                    return View(typle);
                }
                else
                {
                    typle = (_cataloged.GetCategories().ToArray(), false);
                    return View(typle);
                }
            }
            typle = (_cataloged.GetCategories().ToArray(), null);
            return View(typle);
        }
    }
}
