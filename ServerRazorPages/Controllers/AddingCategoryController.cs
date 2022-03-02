using HttpModels;
using Microsoft.AspNetCore.Mvc;

namespace ServerRazorPages.Controllers;

public class AddingCategoryController : Controller
{
    private readonly ICatalog _cataloged;

    public AddingCategoryController(ICatalog cataloged)
    {
        _cataloged = cataloged;
    }
    // GET
    public IActionResult AddingCategory(Guid? id, string name)
    {
        if (HttpContext.Request.Method == "POST")
        {
            if (id is not null && !_cataloged.IsNewCategoryId((Guid)id))
                return View(false);

            _cataloged.AddCategorie(id is null ? new(name) : new((Guid)id, name));
            return View(true);
        }
        return View();
    }
}
