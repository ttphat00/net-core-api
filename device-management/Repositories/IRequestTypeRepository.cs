using device_management.Models;

namespace device_management.Repositories
{
    public interface IRequestTypeRepository
    {
        Task<List<RequestTypeModel>> GetAllRequestType();
    }
}
