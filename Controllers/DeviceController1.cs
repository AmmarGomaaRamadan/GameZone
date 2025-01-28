using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceServices _deviceservice;
        public DeviceController(IDeviceServices deviceservice)
        {
            _deviceservice = deviceservice;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDeviceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _deviceservice.Create(model);
            return RedirectToAction(controllerName: "Game", actionName: "Create");
        }
    }
}
