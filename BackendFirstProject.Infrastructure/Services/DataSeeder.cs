using BackendFirstProject.Core.Entities;
using BackendFirstProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendFirstProject.Infrastructure.Services
{
    public class DataSeeder
    {
        private readonly AppDbContext _context;

        public DataSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void SeedDepartmentsAndPositions()
        {
            Console.WriteLine(" Seeding Departments & Positions...");

            bool changesMade = false; // Track if data was added

            // 1️ Seed 20 Departments
            if (!_context.Departments.Any())
            {
                _context.Departments.AddRange(new List<Department>
                {
                    new() { DepartmentName = "IT" },
                    new() { DepartmentName = "HR" },
                    new() { DepartmentName = "Finance" },
                    new() { DepartmentName = "Marketing" },
                    new() { DepartmentName = "Sales" },
                    new() { DepartmentName = "Operations" },
                    new() { DepartmentName = "Legal" },
                    new() { DepartmentName = "Customer Support" },
                    new() { DepartmentName = "Engineering" },
                    new() { DepartmentName = "QA" },
                    new() { DepartmentName = "Data Science" },
                    new() { DepartmentName = "Security" },
                    new() { DepartmentName = "Administration" },
                    new() { DepartmentName = "Procurement" },
                    new() { DepartmentName = "Training" },
                    new() { DepartmentName = "Internal Audit" },
                    new() { DepartmentName = "Business Development" },
                    new() { DepartmentName = "Research & Development" },
                    new() { DepartmentName = "Medical Services" },
                    new() { DepartmentName = "Facilities Management" }
                });

                changesMade = true;
            }

            //  2️ Seed 20 Positions
            if (!_context.Positions.Any())
            {
                _context.Positions.AddRange(new List<Position>
                {
                    new() { PositionName = "Software Engineer" },
                    new() { PositionName = "HR Manager" },
                    new() { PositionName = "Financial Analyst" },
                    new() { PositionName = "Marketing Specialist" },
                    new() { PositionName = "Sales Executive" },
                    new() { PositionName = "Operations Coordinator" },
                    new() { PositionName = "Legal Advisor" },
                    new() { PositionName = "Customer Service Representative" },
                    new() { PositionName = "Mechanical Engineer" },
                    new() { PositionName = "QA Tester" },
                    new() { PositionName = "Data Scientist" },
                    new() { PositionName = "Security Analyst" },
                    new() { PositionName = "Administrator" },
                    new() { PositionName = "Procurement Officer" },
                    new() { PositionName = "Trainer" },
                    new() { PositionName = "Internal Auditor" },
                    new() { PositionName = "Business Development Executive" },
                    new() { PositionName = "Research Scientist" },
                    new() { PositionName = "Doctor" },
                    new() { PositionName = "Facilities Supervisor" }
                });

                changesMade = true;
            }

            // Save All Changes in One Transaction
            if (changesMade)
            {
                _context.SaveChanges();
                Console.WriteLine(" Departments & Positions Seeding Completed.");
            }
            else
            {
                Console.WriteLine(" Departments & Positions already exist. Skipping seeding.");
            }
        }

        public void SeedEmployees()
        {
            Console.WriteLine("Seeding Employees...");

            try
            {
                var departments = _context.Departments.ToList();
                var positions = _context.Positions.ToList();

                if (!departments.Any() || !positions.Any())
                {
                    Console.WriteLine("❌ Cannot seed employees because departments or positions are missing.");
                    return;
                }

                if (!_context.Employees.Any())  //  Prevent duplicate entries
                {
                    var employees = new List<Employee>
                    {
                        new() { EmployeeNumber = "E001", Name = "John Doe", GenderCode = "M", DepartmentId = departments[0].DepartmentId, PositionId = positions[0].PositionId, Salary = 5000 },
                        new() { EmployeeNumber = "E002", Name = "Jane Smith", GenderCode = "F", DepartmentId = departments[1].DepartmentId, PositionId = positions[1].PositionId, Salary = 4500 },
                        new() { EmployeeNumber = "E003", Name = "Alice Brown", GenderCode = "F", DepartmentId = departments[2].DepartmentId, PositionId = positions[2].PositionId, Salary = 5500 },
                        new() { EmployeeNumber = "E004", Name = "Bob White", GenderCode = "M", DepartmentId = departments[3].DepartmentId, PositionId = positions[3].PositionId, Salary = 4800 },
                        new() { EmployeeNumber = "E005", Name = "Charlie Green", GenderCode = "M", DepartmentId = departments[4].DepartmentId, PositionId = positions[4].PositionId, Salary = 5300 },
                        new() { EmployeeNumber = "E006", Name = "David Black", GenderCode = "M", DepartmentId = departments[5].DepartmentId, PositionId = positions[5].PositionId, Salary = 5200 },
                        new() { EmployeeNumber = "E007", Name = "Emma Wilson", GenderCode = "F", DepartmentId = departments[6].DepartmentId, PositionId = positions[6].PositionId, Salary = 5000 },
                        new() { EmployeeNumber = "E008", Name = "Frank Taylor", GenderCode = "M", DepartmentId = departments[7].DepartmentId, PositionId = positions[7].PositionId, Salary = 4700 },
                        new() { EmployeeNumber = "E009", Name = "Grace Thomas", GenderCode = "F", DepartmentId = departments[8].DepartmentId, PositionId = positions[8].PositionId, Salary = 4900 },
                        new() { EmployeeNumber = "E010", Name = "Hannah Martin", GenderCode = "F", DepartmentId = departments[9].DepartmentId, PositionId = positions[9].PositionId, Salary = 5100 }
                    };

                    _context.Employees.AddRange(employees);
                    _context.SaveChanges();
                    Console.WriteLine(" Employees Seeding Completed.");
                }
                else
                {
                    Console.WriteLine(" Employees already exist. Skipping seeding.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error seeding employees: {ex.Message}");
            }
        }
    }
}
