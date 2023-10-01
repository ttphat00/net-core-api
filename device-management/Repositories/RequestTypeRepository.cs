using device_management.Data;
using device_management.Models;
using Microsoft.EntityFrameworkCore;

namespace device_management.Repositories
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        private readonly DeviceManagementContext _context;

        public RequestTypeRepository(DeviceManagementContext context)
        {
            _context = context;
        }

        public async Task<List<RequestTypeModel>> GetAllRequestType()
        {
            var types = _context.RequestTypes.Select(type => new RequestTypeModel
            {
                RequestTypeId = type.RequestTypeId,
                RequestName = type.RequestName
            });

            return await types.ToListAsync();
        }
    }
}
