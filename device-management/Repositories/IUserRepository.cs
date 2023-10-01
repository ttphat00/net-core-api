using device_management.Models;

namespace device_management.Repositories
{
    public interface IUserRepository
    {
        List<UserModel> GetAllUser(int page = 1);
    }
}
