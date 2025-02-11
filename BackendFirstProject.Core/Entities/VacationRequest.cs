using BackendFirstProject.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class VacationRequest
{
    public int RequestId { get; set; } // Primary Key

    public DateTime RequestSubmissionDate { get; set; }

    [Required, MaxLength(100)]
    public string Description { get; set; }

    // Foreign Key to Employee
    [Required, MaxLength(6)]
    public string EmployeeNumber { get; set; }

    // Navigation Property to Employee
    public Employee Employee { get; set; }

    // Foreign Key to VacationType
    [Required, MaxLength(1)]
    public string VacationTypeCode { get; set; }

    // Navigation Property to VacationType
    public VacationType VacationType { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
   

    [Required]
    public int TotalVacationDays { get; set; }

    // Foreign Key to RequestState
    public int RequestStateId { get; set; }

    
    public RequestState RequestState { get; set; }

    // Foreign Key to ApprovedBy Employee
    [MaxLength(6)]
    public string? ApprovedByEmployeeNumber { get; set; }


    public Employee ApprovedByEmployee { get; set; }

    // Foreign Key to DeclinedBy Employee
    [MaxLength(6)]
    public string? DeclinedByEmployeeNumber { get; set; }

  
    public Employee DeclinedByEmployee { get; set; }
}