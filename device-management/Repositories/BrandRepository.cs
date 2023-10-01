using device_management.Data;
using device_management.Models;
using Microsoft.EntityFrameworkCore;

namespace device_management.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly DeviceManagementContext _context;

        public BrandRepository(DeviceManagementContext context)
        {
            _context = context;
        }

        public async Task<List<BrandModel>> GetAllBrand()
        {
            var brands = _context.Brands.Select(brand => new BrandModel
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
                DeviceType = brand.DeviceType.Name,
                IsDeleted = brand.IsDeleted
            });

            return await brands.ToListAsync();
        }
    }
}
