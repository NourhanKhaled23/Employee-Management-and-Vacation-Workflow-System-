﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendFirstProject.Core.Entities
{
    public class VacationType
    {
        [Key]
        [MaxLength(1)] 
        public string VacationTypeCode { get; set; }

        [Required]
        [MaxLength(20)]
        public string VacationTypeName { get; set; }
       
        public ICollection<VacationRequest> VacationRequests { get; set; }
    }
}
