using HttpModels;
using Microsoft.AspNetCore.Mvc;

namespace ServerRazorPages.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalog _cataloged;
        private readonly IClock _clock;

        public CatalogController(ICatalog cataloged, IClock clock)
        {
            _cataloged = cataloged;
            _clock = clock;
        }

        public IActionResult Catalog(Guid? categoryId = null)
        {
            IReadOnlyCollection<Product> products;
            string userAgent = HttpContext.Request.Headers.UserAgent.ToString();
            if (categoryId is not null)
                products = _cataloged.GetProducts(userAgent, (Guid)categoryId, _clock.GetClock());
            else
                products = _cataloged.GetProducts(userAgent, date: _clock.GetClock());
            return View(products);
        }
    }
}