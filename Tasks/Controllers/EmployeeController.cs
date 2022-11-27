using EmployeeMangement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tasks.Models;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeRepository.GetByIdAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            
            return Ok(employee);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewEmployee([FromBody] EmployeeModel employeeModel)
        {
            var id = await _employeeRepository.AddEmployeeAsync(employeeModel);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return CreatedAtAction(nameof(GetEmployeeById), new { id = id, Controller = "books" }, id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeModel employeeModel, int id)
        {
            await _employeeRepository.UpdateEmployeeAsync(id, employeeModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            int employee = await _employeeRepository.DeleteEmployeeAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
