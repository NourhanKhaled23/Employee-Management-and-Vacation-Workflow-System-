
namespace BackendFirstProject.Core.DTOs
{
    public class PendingVacationRequestDto
    {
        public string Description { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string VacationDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal EmployeeSalary { get; set; }
    }
}
