using Business.Requests;
using Business.Responses;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BootCampProjectAcunmedya1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _service;

        public InstructorController(IInstructorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<InstructorResponse>> Create(CreateInstructorRequest request)
        {
            var result = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorResponse>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<InstructorResponse>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<InstructorResponse>> Update(UpdateInstructorRequest request)
        {
            var result = await _service.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
