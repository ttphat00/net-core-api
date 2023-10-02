using device_management.Models;
using device_management.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace device_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingDevicesController : ControllerBase
    {
        private readonly IBorrowingDeviceRepository _borrowingDeviceRepository;

        public BorrowingDevicesController(IBorrowingDeviceRepository borrowingDeviceRepository)
        {
            _borrowingDeviceRepository = borrowingDeviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBorrowingDevice(string? userId)
        {
            try
            {
                var devices = await _borrowingDeviceRepository.GetAllBorrowingDevice(userId);
                return Ok(devices);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBorrowingDevice(BorrowingDeviceModel model)
        {
            try
            {
                var id = await _borrowingDeviceRepository.CreateBorrowingDevice(model);
                var newDevice = await _borrowingDeviceRepository.GetBorrowingDeviceById(id);
                return StatusCode(StatusCodes.Status201Created, newDevice);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
