
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
            return _context.Devices.Select(d=>new SelectListItem { Value=d.Id.ToString(),Text=d.Name}).ToList();
        }
    }
}
