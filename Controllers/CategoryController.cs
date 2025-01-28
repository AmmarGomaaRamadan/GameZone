using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        //private readonly ApplicationDbContext _context;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
           // _context = context;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Create(CreateCategoryViewModel model) {
            if (!ModelState.IsValid) {
               return View(model);
            }
            await _categoryService.Create(model);
            return RedirectToAction(controllerName:"Game",actionName:"Create");
        }
    }
}
