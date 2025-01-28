namespace GameZone.Services.Devices
{
    public interface IDeviceServices
    {
        IEnumerable<SelectListItem> GetDevices();
        Task Create(CreateDeviceViewModel model);
    }
}
