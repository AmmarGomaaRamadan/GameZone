


using GameZone.Models;
using GameZone.Services.Categories;
using GameZone.Services.Devices;
using GameZone.Services.Games;

namespace GameZone.Controllers
{
    
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IDeviceServices _deviceServices;
        private readonly IGameServices _gameServices;
        public GameController(ApplicationDbContext context ,IGameServices gameServices,
            IDeviceServices deviceServices,ICategoryService categoryServices)
        {
            _context = context;
            _categoryService = categoryServices;
            _deviceServices = deviceServices;
            _gameServices = gameServices;
        }

        public IActionResult Index()
        {
            var model=_gameServices.GetAll();
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var game=_gameServices.GetById(id);
            if(game is null)
                return NotFound();
            return View(game);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameViewModel viewModel = new()
            {
                Categories=_categoryService.GetCategories(),
                GameDevices=_deviceServices.GetDevices(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateGameViewModel model)
        {
            if (!ModelState.IsValid) {
                model.GameDevices= _deviceServices.GetDevices();
                model.Categories= _categoryService.GetCategories();
                return View(model);

            }
            await _gameServices.Create(model);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var Game=_gameServices.GetById(id);
            if(Game is null)
                return NotFound();
            EditGameViewModel game = new EditGameViewModel
            {
                Id = id,
                Categories = _categoryService.GetCategories(),
                GameDevices = _deviceServices.GetDevices(),
                Name = Game.Name,
                CategoryId = Game.CategoryId,
                SelectedDevices = Game.GameDevices.Select(g=>g.DeviceId).ToList(),
                Description = Game.Description,
                CoverName = Game.Cover
            };
            return View(game);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditGameViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                
                return View(viewmodel);

            }
            var game = _gameServices.Update(viewmodel);
            if (game is null)
                return BadRequest();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id) {
            bool isdeleted = _gameServices.Delete(id);
            return isdeleted ? Ok() : BadRequest();
        }
    }
}
