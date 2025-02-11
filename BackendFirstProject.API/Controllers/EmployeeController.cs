using BackendFirstProject.Core.DTOs;
using BackendFirstProject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendFirstProject.API.Controllers
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

        // GET: api/Employee
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        // GET: api/Employee/E001
        [HttpGet("{employeeNumber}")]
        public async Task<IActionResult> GetEmployeeById(string employeeNumber)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeNumber);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { employeeNumber = employee.EmployeeNumber }, employee);
        }

        // PUT: api/Employee/E001
        [HttpPut("{employeeNumber}")]
        public async Task<IActionResult> UpdateEmployee(string employeeNumber, [FromBody] Employee updatedEmployee)
        {
            var result = await _employeeRepository.UpdateEmployeeAsync(employeeNumber, updatedEmployee);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // PUT: api/Employee/E001/VacationDays
        [HttpPut("{employeeNumber}/VacationDays")]
        public async Task<IActionResult> UpdateVacationDays(string employeeNumber, [FromQuery] int daysUsed)
        {
            var result = await _employeeRepository.UpdateVacationDaysAsync(employeeNumber, daysUsed);
            if (!result)
                return BadRequest("Insufficient vacation days or employee not found.");

            return NoContent();
        }

        // DELETE: api/Employee/E001
        [HttpDelete("{employeeNumber}")]
        public async Task<IActionResult> DeleteEmployee(string employeeNumber)
        {
            await _employeeRepository.DeleteEmployeeAsync(employeeNumber);
            return NoContent();
        }

        // GET: api/Employee/PendingVacations
        [HttpGet("PendingVacations")]
        public async Task<IActionResult> GetEmployeesWithPendingVacations()
        {
            var employees = await _employeeRepository.GetEmployeesWithPendingVacationsAsync();
            return Ok(employees);
        }

        // GET: api/Employee/E001/VacationHistory
        [HttpGet("{employeeNumber}/VacationHistory")]
        public async Task<IActionResult> GetEmployeeVacationHistory(string employeeNumber)
        {
            var history = await _employeeRepository.GetEmployeeVacationHistoryAsync(employeeNumber);
            return Ok(history);
        }

        // GET: api/Employee/E001/PendingRequests
        [HttpGet("{employeeNumber}/PendingRequests")]
        public async Task<IActionResult> GetPendingVacationRequests(string employeeNumber)
        {
            var requests = await _employeeRepository.GetPendingVacationRequestsAsync(employeeNumber);
            return Ok(requests);
        }
    }
}