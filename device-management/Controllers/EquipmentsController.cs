using device_management.Models;
using device_management.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace device_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentsController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEquipment()
        {
            try
            {
                var equipments = await _equipmentRepository.GetAllEquipment();
                return Ok(equipments);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment(EquipmentModel model)
        {
            try
            {
                var id = await _equipmentRepository.CreateEquipment(model);
                var newEquipment = await _equipmentRepository.GetEquipmentById(id);
                return StatusCode(StatusCodes.Status201Created, newEquipment);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipment(int id, EquipmentVM model)
        {
            if(id != model.EquipmentId)
            {
                return BadRequest("ID is incorrect!");
            }

            try
            {
                var equipmentId = await _equipmentRepository.UpdateEquipment(model);
                if(equipmentId != 0)
                {
                    var newEquipment = await _equipmentRepository.GetEquipmentById(equipmentId);
                    return Ok(newEquipment);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            try
            {
                var isDeleted = await _equipmentRepository.DeleteEquipment(id);
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
