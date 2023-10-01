using device_management.Models;

namespace device_management.Repositories
{
    public interface IDeviceTypeRepository
    {
        Task<List<DeviceTypeModel>> GetAllDeviceType();
    }
}
