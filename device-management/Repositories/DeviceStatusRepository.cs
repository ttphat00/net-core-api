using device_management.Data;
using device_management.Models;
using Microsoft.EntityFrameworkCore;

namespace device_management.Repositories
{
    public class DeviceStatusRepository : IDeviceStatusRepository
    {
        private readonly DeviceManagementContext _context;

        public DeviceStatusRepository(DeviceManagementContext context)
        {
            _context = context;
        }

        public async Task<List<DeviceStatusModel>> GetAllDeviceStatus()
        {
            var statuses = _context.EquipmentStatuses.Select(status => new DeviceStatusModel
            {
                EquipmentStatusId = status.EquipmentStatusId,
                Name = status.Name
            });

            return await statuses.ToListAsync();
        }
    }
}
