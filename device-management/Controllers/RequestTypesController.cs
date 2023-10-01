using device_management.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace device_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTypesController : ControllerBase
    {
        private readonly IRequestTypeRepository _requestTypeRepository;

        public RequestTypesController(IRequestTypeRepository requestTypeRepository)
        {
            _requestTypeRepository = requestTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequestType()
        {
            try
            {
                var types = await _requestTypeRepository.GetAllRequestType();
                return Ok(types);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
