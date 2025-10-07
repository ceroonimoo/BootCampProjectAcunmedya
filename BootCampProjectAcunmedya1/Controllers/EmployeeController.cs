using Business.Requests;
using Business.Responses;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootCampProjectAcunmedya1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        // POST: api/employee
        [HttpPost]
        public async Task<ActionResult<EmployeeResponse>> Create([FromBody] CreateEmployeeRequest request)
        {
            var result = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/employee
        [HttpPut]
        public async Task<ActionResult<EmployeeResponse>> Update([FromBody] UpdateEmployeeRequest request)
        {
            var result = await _service.UpdateAsync(request);
            return Ok(result);
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        // GET: api/employee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponse>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        // GET: api/employee
        [HttpGet]
        public async Task<ActionResult<List<EmployeeResponse>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}
