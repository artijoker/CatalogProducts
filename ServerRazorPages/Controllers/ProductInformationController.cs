using HttpModels;
using Microsoft.AspNetCore.Mvc;

namespace ServerRazorPages.Controllers
{
    public class ProductInformationController : Controller
    {
        private readonly ICatalog _cataloged;
        
        public ProductInformationController(ICatalog cataloged)
        {
            _cataloged = cataloged;
        }

        
        public IActionResult ProductInformation(Guid id)
        {
            Product? product = _cataloged.GetProductById(id);
            return View(product);
        }
    }
}
