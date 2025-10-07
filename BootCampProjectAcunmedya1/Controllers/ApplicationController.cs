using Business.Requests;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BootCampProjectAcunmedya1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _service;

        public ApplicationController(IApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateApplicationRequest request)
        {
            var response = await _service.AddAsync(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateApplicationRequest request)
        {
            var response = await _service.UpdateAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            return Ok(response);
        }
    }

}
