using device_management.Data;
using device_management.Models;
using Microsoft.EntityFrameworkCore;

namespace device_management.Repositories
{
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        private readonly DeviceManagementContext _context;

        public DeviceTypeRepository(DeviceManagementContext context)
        {
            _context = context;
        }

        public async Task<List<DeviceTypeModel>> GetAllDeviceType()
        {
            var types = _context.DeviceTypes.Select(type => new DeviceTypeModel
            {
                
                DeviceTypeId = type.DeviceTypeId,
                Name = type.Name,
                IsDeleted = type.IsDeleted
            });

            return await types.ToListAsync();
        }
    }
}
