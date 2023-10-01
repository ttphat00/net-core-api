using device_management.Data;
using device_management.Models;
using Microsoft.EntityFrameworkCore;

namespace device_management.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DeviceManagementContext _context;

        public RoleRepository(DeviceManagementContext context)
        {
            _context = context;
        }

        public async Task<List<RoleModel>> GetAllRole()
        {
            var roles = _context.Roles.Select(role => new RoleModel
            {
                RoleId = role.RoleId,
                Name = role.Name,
                IsDeleted = role.IsDeleted
            });

            return await roles.ToListAsync();
        }
    }
}
