


using GameZone.Services.Categories;
using GameZone.Services.Devices;

namespace GameZone.Controllers
{
    
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IDeviceServices _deviceServices;
        public GameController(ApplicationDbContext context ,IDeviceServices deviceServices,ICategoryService categoryServices)
        {
            _context = context;
            _categoryService = categoryServices;
            _deviceServices = deviceServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameViewModel viewModel = new()
            {
                Categories=_categoryService.GetCategories(),
                Devices=_deviceServices.GetDevices(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateGameViewModel model)
        {
            if (!ModelState.IsValid) {
                model.Devices= _deviceServices.GetDevices();
                model.Categories= _categoryService.GetCategories();
                return View(model);

            }
            return View(model);

        }
    }
}
