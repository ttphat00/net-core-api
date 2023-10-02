using device_management.Models;

namespace device_management.Repositories
{
    public interface IBorrowingDeviceRepository
    {
        public Task<List<BorrowingDeviceVM>> GetAllBorrowingDevice(string userId);
        public Task<BorrowingDeviceVM> GetBorrowingDeviceById(int id);
        public Task<int> CreateBorrowingDevice(BorrowingDeviceModel model);
    }
}
