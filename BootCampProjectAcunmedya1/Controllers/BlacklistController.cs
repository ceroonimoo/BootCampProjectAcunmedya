using Business.Requests;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BootCampProjectAcunmedya1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlacklistController : ControllerBase
    {
        private readonly IBlacklistService _blacklistService;

        public BlacklistController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _blacklistService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _blacklistService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBlacklistRequest request)
        {
            var result = await _blacklistService.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBlacklistRequest request)
        {
            var result = await _blacklistService.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blacklistService.DeleteAsync(id);
            return NoContent();
        }
    }

}
