using BackendFirstProject.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Employee
{

    public Employee()
    {
        VacationDaysLeft = 24; // Default vacation balance
    }
    [Key]
    [MaxLength(6)]
    public string EmployeeNumber { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public int PositionId { get; set; }
    public Position Position { get; set; }

    [MaxLength(1)]
    public string GenderCode { get; set; }

    [MaxLength(6)]

    public string? ReportedToEmployeeNumber { get; set; }  // Nullable FK
    
    public Employee? ReportedTo { get; set; } // Manager Relationship

    public int VacationDaysLeft { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }

    // Navigation Property to VacationRequests
    public ICollection<VacationRequest> VacationRequests { get; set; }
}


