namespace GameZone.Services.Devices
{
    public interface IDeviceServices
    {
        IEnumerable<SelectListItem> GetDevices();
    }
}
