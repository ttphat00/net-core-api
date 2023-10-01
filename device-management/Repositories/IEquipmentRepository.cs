using device_management.Models;

namespace device_management.Repositories
{
    public interface IEquipmentRepository
    {
        public Task<List<EquipmentVM>> GetAllEquipment();
        public Task<EquipmentVM> GetEquipmentById(int equipmentId);
        public Task<int> CreateEquipment(EquipmentModel model);
        public Task<int> UpdateEquipment(EquipmentVM model);
        public Task<bool> DeleteEquipment(int equipmentId);
    }
}
