using device_management.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace device_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceStatusesController : ControllerBase
    {
        private readonly IDeviceStatusRepository _deviceStatusRepository;

        public DeviceStatusesController(IDeviceStatusRepository deviceStatusRepository)
        {
            _deviceStatusRepository = deviceStatusRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeviceStatus()
        {
            try
            {
                var statuses = await _deviceStatusRepository.GetAllDeviceStatus();
                return Ok(statuses);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
