using device_management.Data;
using device_management.Helpers;
using device_management.Models;
using Microsoft.EntityFrameworkCore;

namespace device_management.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DeviceManagementContext _context;
        private static int pageSize = 1; 

        public UserRepository(DeviceManagementContext context) 
        {
            _context = context;
        }

        public List<UserModel> GetAllUser(int page = 1)
        {
            var source = _context.Users.Include(user => user.Role).AsQueryable();

            var users = PagedList<User>.ToPagedList(source, page, pageSize);

            var result = users.Select(user => new UserModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Avatar = user.Avatar,
                Phone = user.Phone,
                Gender = user.Gender,
                Role = user.Role.Name,
                IsDeleted = user.IsDeleted,
                CreatedAt = user.CreatedAt
            });

            return result.ToList();
        }
    }
}
