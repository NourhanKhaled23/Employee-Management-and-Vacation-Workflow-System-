using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendFirstProject.Core.DTOs
{
    namespace BackendFirstProject.Core.DTOs
    {
        public class VacationRequestDto
        {
            public string EmployeeNumber { get; set; }
            public string Description { get; set; }
            public string VacationTypeCode { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int TotalVacationDays { get; set; }
        }
    }
}
