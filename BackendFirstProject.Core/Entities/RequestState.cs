using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendFirstProject.Core.Entities
{
    public class RequestState
    {
        [Key]
        public int StateId { get; set; }

        [Required]
        [MaxLength(10)]
        public string StateName { get; set; } // Example: "Submitted", "Approved", "Declined"

        public List<VacationRequest> VacationRequests { get; set; } = new();
    }
}
