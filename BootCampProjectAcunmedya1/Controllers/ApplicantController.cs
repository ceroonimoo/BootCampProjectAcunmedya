using Business.Requests;
using Business.Responses;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _service;

        public ApplicantController(IApplicantService service)
        {
            _service = service;
        }

        [HttpPost("blacklist")]
        public async Task<ActionResult<BlacklistResponse>> CreateBlacklist(CreateBlacklistRequest request)
        {
            var result = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("blacklist")]
        public async Task<ActionResult<BlacklistResponse>> UpdateBlacklist(UpdateBlacklistRequest request)
        {
            var result = await _service.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete("blacklist/{id}")]
        public async Task<IActionResult> DeleteBlacklist(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("blacklist/{id}")]
        public async Task<ActionResult<BlacklistResponse>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("blacklist")]
        public async Task<ActionResult<List<BlacklistResponse>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}
