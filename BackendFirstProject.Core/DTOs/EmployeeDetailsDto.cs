namespace BackendFirstProject.Core.DTOs
{
    public class EmployeeDetailsDto
    {
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string ReportedTo { get; set; }
        public int VacationDaysLeft { get; set; }
    }
}
