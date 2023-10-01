using device_management.Data;
using device_management.Models;
using Microsoft.EntityFrameworkCore;

namespace device_management.Repositories
{
    public class RequestStatusRepository : IRequestStatusRepository
    {
        private readonly DeviceManagementContext _context;

        public RequestStatusRepository(DeviceManagementContext context)
        {
            _context = context;
        }

        public async Task<List<RequestStatusModel>> GetAllRequestStatus()
        {
            var statuses = _context.RequestStatuses.Select(status => new RequestStatusModel
            {
                RequestStatusId = status.RequestStatusId,
                RequestStatusName = status.RequestStatusName
            });

            return await statuses.ToListAsync();
        }
    }
}
