namespace BackendFirstProject.Core.DTOs
{
    public class EmployeeVacationHistoryDto
    {
        public string VacationType { get; set; }
        public string Description { get; set; }
        public int TotalVacationDays { get; set; }
        public string ApprovedBy { get; set; }
    }
}
