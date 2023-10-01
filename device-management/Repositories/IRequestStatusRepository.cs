using device_management.Models;

namespace device_management.Repositories
{
    public interface IRequestStatusRepository
    {
        Task<List<RequestStatusModel>> GetAllRequestStatus();
    }
}
