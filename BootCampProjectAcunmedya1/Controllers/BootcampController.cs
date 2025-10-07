using Business.Requests;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BootCampProjectAcunmedya1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BootcampController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;

        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _bootcampService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _bootcampService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBootcampRequest request) =>
            Ok(await _bootcampService.AddAsync(request));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBootcampRequest request) =>
            Ok(await _bootcampService.UpdateAsync(request));

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBootcampRequest request)
        {
            await _bootcampService.DeleteAsync(request);
            return NoContent();
        }
    }

}
