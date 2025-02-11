public class VacationRequestResponseDto
{
    public int RequestId { get; set; }
    public string Description { get; set; }
    public string EmployeeNumber { get; set; }
    public string EmployeeName { get; set; }  
    public string VacationTypeCode { get; set; }
    public string VacationTypeName { get; set; }  
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime SubmissionDate { get; set; }
    public int TotalVacationDays { get; set; }
    public string RequestState { get; set; }  // Show State Name instead of ID
}
