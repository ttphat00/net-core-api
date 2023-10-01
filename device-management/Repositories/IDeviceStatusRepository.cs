using device_management.Models;

namespace device_management.Repositories
{
    public interface IDeviceStatusRepository
    {
        Task<List<DeviceStatusModel>> GetAllDeviceStatus();
    }
}
