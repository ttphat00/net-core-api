using device_management.Data;
using device_management.Models;
using Microsoft.EntityFrameworkCore;

namespace device_management.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly DeviceManagementContext _context;

        public EquipmentRepository(DeviceManagementContext context)
        {
            _context = context;
        }

        public async Task<int> CreateEquipment(EquipmentModel model)
        {
            var equipment = new Equipment
            {
                Name = model.Name,
                Description = model.Description,
                BrandId = model.BrandId,
                StatusId = model.StatusId
            };
            _context.Equipments.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment.EquipmentId;
        }

        public async Task<EquipmentVM> GetEquipmentById(int equipmentId)
        {
            var equipment = await _context.Equipments.Include(e => e.Brand)
                                                    .Include(e => e.Status)
                                                    .SingleOrDefaultAsync(e => e.EquipmentId == equipmentId);
            return new EquipmentVM
            {
                EquipmentId = equipment.EquipmentId,
                Name = equipment.Name,
                Description = equipment.Description,
                Image = equipment.Image,
                BrandId = equipment.BrandId,
                Brand = equipment.Brand.Name,
                StatusId = equipment.StatusId,
                Status = equipment.Status.Name,
                IsDeleted = equipment.IsDeleted,
                CreatedAt = equipment.CreatedAt,
                UpdatedAt = equipment.UpdatedAt
            };
        }

        public async Task<bool> DeleteEquipment(int equipmentId)
        {
            var equipment = await _context.Equipments.FindAsync(equipmentId);
            if (equipment != null)
            {
                equipment.IsDeleted = true;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<EquipmentVM>> GetAllEquipment()
        {
            var equipments = _context.Equipments.Select(equipment => new EquipmentVM
            {
                EquipmentId = equipment.EquipmentId,
                Name = equipment.Name,
                Description = equipment.Description,
                Image = equipment.Image,
                BrandId = equipment.BrandId,
                Brand = equipment.Brand.Name,
                StatusId = equipment.StatusId,
                Status = equipment.Status.Name,
                IsDeleted = equipment.IsDeleted,
                CreatedAt = equipment.CreatedAt,
                UpdatedAt = equipment.UpdatedAt
            });

            return await equipments.ToListAsync();
        }

        public async Task<int> UpdateEquipment(EquipmentVM model)
        {
            var equipment = await _context.Equipments.FindAsync(model.EquipmentId);
            if(equipment != null)
            {
                equipment.Name = model.Name;
                equipment.Description = model.Description;
                equipment.BrandId = model.BrandId;
                equipment.StatusId = model.StatusId;
                equipment.UpdatedAt = DateTime.Today;

                await _context.SaveChangesAsync();
                return equipment.EquipmentId;
            }
            return 0;
        }
    }
}
