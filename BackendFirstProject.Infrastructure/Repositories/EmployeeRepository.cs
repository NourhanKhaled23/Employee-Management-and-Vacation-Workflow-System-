using Microsoft.EntityFrameworkCore;
using BackendFirstProject.Core.Entities;
using BackendFirstProject.Core.Interfaces;
using BackendFirstProject.Core.DTOs;
using BackendFirstProject.Infrastructure.Data;

namespace BackendFirstProject.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        //  1️ Get All Employees
        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Select(e => new EmployeeDto
                {
                    EmployeeNumber = e.EmployeeNumber,
                    Name = e.Name,
                    Department = e.Department != null ? e.Department.DepartmentName : "N/A",
                    Salary = e.Salary
                })
                .AsNoTracking()
                .ToListAsync();
        }

        //  2️ Get Employee by ID
        public async Task<EmployeeDetailsDto> GetEmployeeByIdAsync(string employeeNumber)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Position)
                .Include(e => e.ReportedTo) 
                .Where(e => e.EmployeeNumber == employeeNumber)
                .Select(e => new EmployeeDetailsDto
                {
                    EmployeeNumber = e.EmployeeNumber,
                    Name = e.Name,
                    DepartmentName = e.Department != null ? e.Department.DepartmentName : "N/A",
                    PositionName = e.Position != null ? e.Position.PositionName : "N/A",
                    ReportedTo = e.ReportedTo != null ? e.ReportedTo.Name : "N/A", 
                    VacationDaysLeft = e.VacationDaysLeft
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }


        //  3️ Add Employee
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        //  4️ Update Employee Info
        public async Task<bool> UpdateEmployeeAsync(string employeeNumber, Employee updatedEmployee)
        {
            var employee = await _context.Employees.FindAsync(employeeNumber);
            if (employee == null) return false;

            employee.Name = updatedEmployee.Name;
            employee.DepartmentId = updatedEmployee.DepartmentId;
            employee.PositionId = updatedEmployee.PositionId;
            employee.Salary = updatedEmployee.Salary;

            await _context.SaveChangesAsync();
            return true;
        }

        //  5️ Update Vacation Days
        public async Task<bool> UpdateVacationDaysAsync(string employeeNumber, int daysUsed)
        {
            var employee = await _context.Employees.FindAsync(employeeNumber);
            if (employee == null) return false;

            if (employee.VacationDaysLeft >= daysUsed)
            {
                employee.VacationDaysLeft -= daysUsed;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // 6️ Delete Employee
        public async Task DeleteEmployeeAsync(string employeeNumber)
        {
            var employee = await _context.Employees.FindAsync(employeeNumber);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        //  7️ Get Employees with Pending Vacation Requests
        public async Task<List<EmployeePendingVacationDto>> GetEmployeesWithPendingVacationsAsync()
        {
            return await _context.Employees
                .Where(e => e.VacationRequests.Any(v => v.RequestStateId == 1)) // Ensure pending requests exist
                .Select(e => new EmployeePendingVacationDto
                {
                    EmployeeNumber = e.EmployeeNumber,
                    Name = e.Name,
                    PendingRequests = e.VacationRequests.Count(v => v.RequestStateId == 1)
                })
                .AsNoTracking()
                .ToListAsync();
        }


        //8️ Get Employee Vacation History (Approved Requests)
        public async Task<List<EmployeeVacationHistoryDto>> GetEmployeeVacationHistoryAsync(string employeeNumber)
        {
            return await _context.VacationRequests
                .Include(v => v.VacationType)
                .Include(v => v.ApprovedByEmployee)
                .Where(v => v.EmployeeNumber == employeeNumber && v.RequestStateId == 2)
                .Select(v => new EmployeeVacationHistoryDto
                {
                    VacationType = v.VacationType != null ? v.VacationType.VacationTypeName : "N/A",
                    Description = v.Description,
                    TotalVacationDays = v.TotalVacationDays,
                    ApprovedBy = v.ApprovedByEmployee != null ? v.ApprovedByEmployee.Name : "N/A"
                })
                .AsNoTracking()
                .ToListAsync();
        }

        // 9 Get Pending Vacation Requests for an Approver
        public async Task<List<PendingVacationRequestDto>> GetPendingVacationRequestsAsync(string approverEmployeeNumber)
        {
            return await _context.VacationRequests
                .Include(v => v.Employee)
                .Where(v => v.RequestStateId == 1 && v.ApprovedByEmployeeNumber == approverEmployeeNumber)
                .Select(v => new PendingVacationRequestDto
                {
                    Description = v.Description,
                    EmployeeNumber = v.EmployeeNumber,
                    EmployeeName = v.Employee != null ? v.Employee.Name : "N/A",
                    SubmittedOn = v.RequestSubmissionDate,
                    VacationDuration = $"{(v.EndDate - v.StartDate).TotalDays} days",
                    StartDate = v.StartDate,
                    EndDate = v.EndDate,
                    EmployeeSalary = v.Employee.Salary
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
