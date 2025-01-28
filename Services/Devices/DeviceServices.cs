
namespace GameZone.Services.Devices
{
    public class DeviceServices : IDeviceServices
    {
        private readonly ApplicationDbContext _context;

        public DeviceServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetDevices()
        {
            return _context.Devices.Select(d=>new SelectListItem { Value=d.Id.ToString(),Text=d.Name}).AsNoTracking().ToList();
        }

        public async Task Create(CreateDeviceViewModel model)
        {
            var device = new Device { Name = model.Name, Icon = model.Icon };
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
        }
    }
}
