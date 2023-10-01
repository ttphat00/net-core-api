using device_management.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace device_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestStatusesController : ControllerBase
    {
        private readonly IRequestStatusRepository _requestStatusRepository;

        public RequestStatusesController(IRequestStatusRepository requestStatusRepository)
        {
            _requestStatusRepository = requestStatusRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequestStatus()
        {
            try
            {
                var statuses = await _requestStatusRepository.GetAllRequestStatus();
                return Ok(statuses);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
