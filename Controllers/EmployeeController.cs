using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RosterManagementSystem.DTOs.Employee;
using RosterManagementSystem.Services.Interfaces;

namespace RosterManagementSystem.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllAsync();

            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployeeDto dto)
        {
            var employee = await _employeeService.AddAsync(dto);

            return CreatedAtAction(nameof(GetEmployeeById),
                new { id = employee.Id }, employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto dto)
        {
            var employee = await _employeeService.UpdateAsync(id, dto);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _employeeService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
