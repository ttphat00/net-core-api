using device_management.Models;

namespace device_management.Repositories
{
    public interface IRoleRepository
    {
        Task<List<RoleModel>> GetAllRole();
    }
}
