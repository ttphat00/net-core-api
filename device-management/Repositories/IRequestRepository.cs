using device_management.Models;

namespace device_management.Repositories
{
    public interface IRequestRepository
    {
        public Task<List<RequestVM>> GetAllRequest();
        public Task<RequestVM> GetRequestById(int requestId);
        public Task<RequestVM> GetRequestByUserId(int userId);
        public Task<int> CreateRequest(RequestModel model);
        public Task<int> UpdateRequest(int id, RequestModel model);
        public Task<bool> DeleteRequest(int requestId);
    }
}
