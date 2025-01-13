
namespace GameZone.Services.Categories
{
    public interface ICategoryService
    {
        IEnumerable<SelectListItem> GetCategories();
    }
}
