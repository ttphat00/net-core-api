using device_management.Data;
using device_management.Models;
using Microsoft.EntityFrameworkCore;

namespace device_management.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DeviceManagementContext _context;

        public RequestRepository(DeviceManagementContext context)
        {
            _context = context;
        }

        public async Task<int> CreateRequest(RequestModel model)
        {
            var request = new Request
            {
                RequestTypeId = model.RequestTypeId,
                RequestStatusId = model.RequestStatusId,
                CreatedBy = model.SenderId,
                EquipmentId = model.EquipmentId
            };
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request.RequestId;
        }

        public async Task<bool> DeleteRequest(int requestId)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request != null)
            {
                request.IsDeleted = true;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<RequestVM>> GetAllRequest()
        {
            var requests = _context.Requests.Select(request => new RequestVM
            {
                RequestId = request.RequestId,
                Message = request.Message,
                RequestType = request.RequestType.RequestName,
                RequestStatus = request.RequestStatus.RequestStatusName,
                Sender = new
                {
                    FirstName = request.User.FirstName,
                    LastName = request.User.LastName,
                    Email = request.User.Email
                },
                EquipmentName = request.Equipment.Name,
                IsDeleted = request.IsDeleted,
                CreatedAt = request.CreatedAt,
                UpdatedAt = request.UpdatedAt
            });

            return await requests.ToListAsync();
        }

        public async Task<RequestVM> GetRequestById(int requestId)
        {
            var request = await _context.Requests.Include(r => r.RequestType)
                                                    .Include(r => r.RequestStatus)
                                                    .Include(r => r.User)
                                                    .Include(r => r.Equipment)
                                                    .SingleOrDefaultAsync(r => r.RequestId == requestId);
            if (request != null)
            {
                return new RequestVM
                {
                    RequestId = request.RequestId,
                    Message = request.Message,
                    RequestType = request.RequestType.RequestName,
                    RequestStatus = request.RequestStatus.RequestStatusName,
                    Sender = new
                    {
                        FirstName = request.User.FirstName,
                        LastName = request.User.LastName,
                        Email = request.User.Email
                    },
                    EquipmentName = request.Equipment.Name,
                    IsDeleted = request.IsDeleted,
                    CreatedAt = request.CreatedAt,
                    UpdatedAt = request.UpdatedAt
                };
            }
            return null;
        }

        public async Task<RequestVM> GetRequestByUserId(int userId)
        {
            var request = await _context.Requests.Include(r => r.RequestType)
                                                    .Include(r => r.RequestStatus)
                                                    .Include(r => r.User)
                                                    .Include(r => r.Equipment)
                                                    .SingleOrDefaultAsync(r => r.User.UserId == userId);
            if(request != null)
            {
                return new RequestVM
                {
                    RequestId = request.RequestId,
                    Message = request.Message,
                    RequestType = request.RequestType.RequestName,
                    RequestStatus = request.RequestStatus.RequestStatusName,
                    Sender = new
                    {
                        FirstName = request.User.FirstName,
                        LastName = request.User.LastName,
                        Email = request.User.Email
                    },
                    EquipmentName = request.Equipment.Name,
                    IsDeleted = request.IsDeleted,
                    CreatedAt = request.CreatedAt,
                    UpdatedAt = request.UpdatedAt
                };
            }
            return null;
        }

        public async Task<int> UpdateRequest(int id, RequestModel model)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request != null)
            {
                request.RequestStatusId = model.RequestStatusId;
                request.Message = model.Message;
                request.UpdatedAt = DateTime.Today;

                await _context.SaveChangesAsync();
                return request.RequestId;
            }
            return 0;
        }
    }
}
