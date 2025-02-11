using BackendFirstProject.Core.DTOs;
using BackendFirstProject.Core.Entities;

namespace BackendFirstProject.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        //CRUD Methods
        Task<List<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDetailsDto> GetEmployeeByIdAsync(string employeeNumber);
        Task AddEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(string employeeNumber, Employee updatedEmployee);
        Task<bool> UpdateVacationDaysAsync(string employeeNumber, int daysUsed);
        Task DeleteEmployeeAsync(string employeeNumber);

        // LINQ Queries
        Task<List<EmployeePendingVacationDto>> GetEmployeesWithPendingVacationsAsync();
        Task<List<EmployeeVacationHistoryDto>> GetEmployeeVacationHistoryAsync(string employeeNumber);
        Task<List<PendingVacationRequestDto>> GetPendingVacationRequestsAsync(string approverEmployeeNumber);
    }
}
