using device_management.Data;
using device_management.Models;
using Microsoft.EntityFrameworkCore;

namespace device_management.Repositories
{
    public class BorrowingDeviceRepository : IBorrowingDeviceRepository
    {
        private readonly DeviceManagementContext _context;

        public BorrowingDeviceRepository(DeviceManagementContext context)
        {
            _context = context;
        }

        public async Task<int> CreateBorrowingDevice(BorrowingDeviceModel model)
        {
            var equipment = new BorrowingEquipment
            {
                FromTime = model.FromTime,
                ToTime = model.ToTime,
                UserId = model.UserId,
                EquipmentId = model.EquipmentId
            };
            _context.BorrowingEquipments.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment.EquipmentId;
        }

        public async Task<List<BorrowingDeviceVM>> GetAllBorrowingDevice(string userId)
        {
            var equipments = _context.BorrowingEquipments.AsQueryable();
            if(!string.IsNullOrEmpty(userId))
            {
                equipments = equipments.Where(e => e.UserId == Convert.ToInt32(userId));
            }
            var result = equipments.Select(equipment => new BorrowingDeviceVM
            {
                FromTime = equipment.FromTime,
                ToTime = equipment.ToTime,
                UserId = equipment.UserId,
                User = new
                {
                    FirstName = equipment.User.FirstName,
                    LastName = equipment.User.LastName,
                    Email = equipment.User.Email
                },
                EquipmentId = equipment.EquipmentId,
                EquipmentName = equipment.Equipment.Name,
                IsDeleted = equipment.IsDeleted,
                CreatedAt = equipment.CreatedAt,
                UpdatedAt = equipment.UpdatedAt
            });

            return await result.ToListAsync();
        }

        public async Task<BorrowingDeviceVM> GetBorrowingDeviceById(int id)
        {
            var equipment = await _context.BorrowingEquipments.Include(e => e.User)
                                                    .Include(e => e.Equipment)
                                                    .SingleOrDefaultAsync(e => e.EquipmentId == id);
            if (equipment != null)
            {
                return new BorrowingDeviceVM
                {
                    FromTime = equipment.FromTime,
                    ToTime = equipment.ToTime,
                    UserId = equipment.UserId,
                    User = new
                    {
                        FirstName = equipment.User.FirstName,
                        LastName = equipment.User.LastName,
                        Email = equipment.User.Email
                    },
                    EquipmentId = equipment.EquipmentId,
                    EquipmentName = equipment.Equipment.Name,
                    IsDeleted = equipment.IsDeleted,
                    CreatedAt = equipment.CreatedAt,
                    UpdatedAt = equipment.UpdatedAt
                };
            }
            return null;
        }
    }
}
