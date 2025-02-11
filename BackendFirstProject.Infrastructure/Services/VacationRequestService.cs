using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendFirstProject.Core.Entities;
using BackendFirstProject.Core.Interfaces;
using BackendFirstProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendFirstProject.Infrastructure.Services
{
    public class VacationRequestService
    {
        private readonly IVacationRequestRepository _vacationRequestRepository;
        private readonly AppDbContext _context; 

        public VacationRequestService(IVacationRequestRepository vacationRequestRepository, AppDbContext context)
        {
            _vacationRequestRepository = vacationRequestRepository;
            _context = context;
        }

        
        public async Task<bool> SubmitVacationRequestAsync(VacationRequest request)
        {
           
            bool overlapExists = await _context.VacationRequests
                .AnyAsync(vr =>
                    vr.EmployeeNumber == request.EmployeeNumber &&
                    vr.RequestStateId == 1 && // Pending requests
                    (
                        (request.StartDate >= vr.StartDate && request.StartDate <= vr.EndDate) ||
                        (request.EndDate >= vr.StartDate && request.EndDate <= vr.EndDate) ||
                        (request.StartDate <= vr.StartDate && request.EndDate >= vr.EndDate)
                    )
                );

            if (overlapExists)
            {
                Console.WriteLine("❌ Overlapping vacation request exists for the employee.");
                return false;
            }

           
            request.RequestSubmissionDate = DateTime.UtcNow;
            request.RequestStateId = 1; // 1 means Submitted (pending)
            await _vacationRequestRepository.AddAsync(request);
            Console.WriteLine("✅ Vacation request submitted successfully.");
            return true;
        }

     
        public async Task<bool> ApproveVacationRequestAsync(int requestId, string approverEmployeeNumber)
        {
         
            var request = await _vacationRequestRepository.GetByIdAsync(requestId);
            if (request == null || request.RequestStateId != 1)
            {
                Console.WriteLine("❌ Vacation request not found or not pending.");
                return false;
            }

            // Prevent self-approval: check if the approver is the same as the requestor.
            if (request.EmployeeNumber.Equals(approverEmployeeNumber, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("❌ An employee cannot approve their own vacation request.");
                return false;
            }

            // Proceed with approval.
            request.RequestStateId = 2; // 2 = Approved
            request.ApprovedByEmployeeNumber = approverEmployeeNumber;
            await _vacationRequestRepository.UpdateAsync(request);

            // Update the employee's vacation days.
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == request.EmployeeNumber);
            if (employee == null)
            {
                Console.WriteLine("❌ Employee not found.");
                return false;
            }
            if (employee.VacationDaysLeft < request.TotalVacationDays)
            {
                Console.WriteLine("❌ Not enough vacation days available.");
                return false;
            }

            employee.VacationDaysLeft -= request.TotalVacationDays;
            await _context.SaveChangesAsync();
            Console.WriteLine("✅ Vacation request approved successfully.");
            return true;
        }

        public async Task<bool> DeclineVacationRequestAsync(int requestId, string declinerEmployeeNumber)
        {
            var request = await _vacationRequestRepository.GetByIdAsync(requestId);
            if (request == null || request.RequestStateId != 1)
            {
                Console.WriteLine("❌ Vacation request not found or not pending.");
                return false;
            }

            //check if the decliner is the same as the requestor.
            if (request.EmployeeNumber.Equals(declinerEmployeeNumber, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("❌ An employee cannot decline their own vacation request.");
                return false;
            }

            request.RequestStateId = 3; // 3 = Declined
            request.DeclinedByEmployeeNumber = declinerEmployeeNumber;
            await _vacationRequestRepository.UpdateAsync(request);
            Console.WriteLine("✅ Vacation request declined successfully.");
            return true;
        }


       
        public async Task<IEnumerable<VacationRequest>> GetPendingRequestsAsync()
        {
            return await _vacationRequestRepository.GetPendingRequestsAsync();
        }
    }
}
