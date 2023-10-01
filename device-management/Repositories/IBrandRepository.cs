using device_management.Models;

namespace device_management.Repositories
{
    public interface IBrandRepository
    {
        Task<List<BrandModel>> GetAllBrand();
    }
}
