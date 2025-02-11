using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//JOIN TABLE Employee ↔ VacationRequest (Approvals)
namespace BackendFirstProject.Core.Entities
{
    public class EmployeeVacationApproval
    {
        [Key]
        public int Id { get; set; }

        public string EmployeeNumber { get; set; } // FK
        public int VacationRequestId { get; set; } // FK

        public Employee Employee { get; set; }
        public VacationRequest VacationRequest { get; set; }
    }

}
