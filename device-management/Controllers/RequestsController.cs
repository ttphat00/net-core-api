using device_management.Models;
using device_management.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace device_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestRepository _requestRepository;

        public RequestsController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequest()
        {
            try
            {
                var requests = await _requestRepository.GetAllRequest();
                return Ok(requests);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestByUserId(int id)
        {
            try
            {
                var request = await _requestRepository.GetRequestByUserId(id);
                if (request != null)
                {
                    return Ok(request);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(RequestModel model)
        {
            try
            {
                var id = await _requestRepository.CreateRequest(model);
                var newRequest = await _requestRepository.GetRequestById(id);
                return StatusCode(StatusCodes.Status201Created, newRequest);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, RequestModel model)
        {
            try
            {
                var requestId = await _requestRepository.UpdateRequest(id, model);
                if (requestId != 0)
                {
                    var newRequest = await _requestRepository.GetRequestById(requestId);
                    return Ok(newRequest);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            try
            {
                var isDeleted = await _requestRepository.DeleteRequest(id);
                if (isDeleted)
                {
                    return Ok("Deleted successfully!");
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
