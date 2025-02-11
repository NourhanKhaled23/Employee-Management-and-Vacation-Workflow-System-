using BackendFirstProject.Core.DTOs;
using BackendFirstProject.Core.Entities;
using BackendFirstProject.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace BackendFirstProject.Infrastructure.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        // Get All Employees
        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        //  Get Employee by ID
        public async Task<EmployeeDetailsDto> GetEmployeeByIdAsync(string employeeNumber)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(employeeNumber);
        }

        // Add Employee
        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            try
            {
                await _employeeRepository.AddEmployeeAsync(employee);
                _logger.LogInformation($"✅ Employee {employee.EmployeeNumber} added.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error adding employee: {ex.Message}");
                return false;
            }
        }

        //  Update Employee Info
        public async Task<bool> UpdateEmployeeInfoAsync(string employeeNumber, Employee updatedEmployee)
        {
            try
            {
                var result = await _employeeRepository.UpdateEmployeeAsync(employeeNumber, updatedEmployee);
                if (!result)
                {
                    _logger.LogWarning($"⚠ Employee {employeeNumber} not found.");
                    return false;
                }

                _logger.LogInformation($"✅ Employee {employeeNumber} updated.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error updating employee: {ex.Message}");
                return false;
            }
        }

        //  Approve Vacation Request
        public async Task<bool> ApproveVacationRequestAsync(string employeeNumber, int daysRequested)
        {
            try
            {
                var result = await _employeeRepository.UpdateVacationDaysAsync(employeeNumber, daysRequested);
                if (!result)
                {
                    _logger.LogWarning($"⚠ Employee {employeeNumber} does not have enough vacation days.");
                    return false;
                }

                _logger.LogInformation($"✅ Approved vacation for {employeeNumber}. Days left updated.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error approving vacation request: {ex.Message}");
                return false;
            }
        }

        //  Delete Employee
        public async Task<bool> DeleteEmployeeAsync(string employeeNumber)
        {
            try
            {
                await _employeeRepository.DeleteEmployeeAsync(employeeNumber);
                _logger.LogInformation($"✅ Employee {employeeNumber} deleted.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error deleting employee: {ex.Message}");
                return false;
            }
        }
    }
}
