using BackendFirstProject.Core.DTOs;
using BackendFirstProject.Core.DTOs.BackendFirstProject.Core.DTOs;
using BackendFirstProject.Core.Entities;
using BackendFirstProject.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendFirstProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationRequestController : ControllerBase
    {
        private readonly VacationRequestService _vacationRequestService;

        public VacationRequestController(VacationRequestService vacationRequestService)
        {
            _vacationRequestService = vacationRequestService;
        }

        // POST: api/VacationRequest
        [HttpPost]
        
        public async Task<IActionResult> SubmitVacationRequest([FromBody] VacationRequestDto dto)
        {
            // Map DTO to entity
            var request = new VacationRequest
            {
                EmployeeNumber = dto.EmployeeNumber,
                Description = dto.Description,
                VacationTypeCode = dto.VacationTypeCode,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                TotalVacationDays = dto.TotalVacationDays,
                RequestSubmissionDate = DateTime.UtcNow,
                RequestStateId = 1 // 1 means "Submitted"
                                  
            };

            // Call service to process submission (e.g., check overlaps, add to database)
            var result = await _vacationRequestService.SubmitVacationRequestAsync(request);
            if (result)
                return Ok("Vacation request submitted successfully.");
            else
                return BadRequest("An overlapping vacation request exists or submission failed.");
        }



        // GET: api/VacationRequest/Pending
        // Retrieves all pending vacation requests.
        [HttpGet("Pending")]
        public async Task<IActionResult> GetPendingVacationRequests()
        {
            var requests = await _vacationRequestService.GetPendingRequestsAsync();

            // Map Entity to DTO
            var response = requests.Select(vr => new VacationRequestResponseDto
            {
                RequestId = vr.RequestId,
                Description = vr.Description,
                EmployeeNumber = vr.EmployeeNumber,
                EmployeeName = vr.Employee?.Name,  
                VacationTypeCode = vr.VacationTypeCode,
                VacationTypeName = vr.VacationType?.VacationTypeName,  
                StartDate = vr.StartDate,
                EndDate = vr.EndDate,
                SubmissionDate = vr.RequestSubmissionDate,
                TotalVacationDays = vr.TotalVacationDays,
                RequestState = vr.RequestState?.StateName  
            }).ToList();

            return Ok(response);
        }




        // PUT: api/VacationRequest/Approve/{id}
        // Approves a vacation request.
        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> ApproveVacationRequest(int id, [FromQuery] string approverEmployeeNumber)
        {
            if (await _vacationRequestService.ApproveVacationRequestAsync(id, approverEmployeeNumber))
                return Ok("Vacation request approved successfully.");
            else
                return BadRequest("Unable to approve vacation request.");
        }

        // PUT: api/VacationRequest/Decline/{id}
        // Declines a vacation request.
        [HttpPut("Decline/{id}")]
        public async Task<IActionResult> DeclineVacationRequest(int id, [FromQuery] string declinerEmployeeNumber)
        {
            if (await _vacationRequestService.DeclineVacationRequestAsync(id, declinerEmployeeNumber))
                return Ok("Vacation request declined successfully.");
            else
                return BadRequest("Unable to decline vacation request.");
        }
    }
}
