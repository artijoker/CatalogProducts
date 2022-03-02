namespace HttpModels;

public interface ICatalog
{
    IReadOnlyList<Product> GetProducts(string userAgent, Guid? categoryId = null, DateTime? date = null);
    Product GetProductById(Guid id);
    Category GetCategoryById(Guid id);
    void AddProduct(Product product);
    void AddCategorie(Category category);
    IReadOnlyList<Category> GetCategories();

    bool IsNewCategoryId(Guid id);
}