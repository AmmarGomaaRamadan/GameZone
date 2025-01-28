

namespace GameZone.Services.Categories
{
    public class CategoryServices : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetCategories()
        {
            return _context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).AsNoTracking().ToList();
        }
        public async Task Create(CreateCategoryViewModel model)
        {
            var category = new Category { Name = model.Name ,Description=model.Description};
             _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            
        }

       
        

    }
}
