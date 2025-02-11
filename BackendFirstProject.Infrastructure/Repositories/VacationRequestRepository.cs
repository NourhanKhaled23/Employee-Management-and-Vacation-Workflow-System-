using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendFirstProject.Core.Entities;
using BackendFirstProject.Core.Interfaces;
using BackendFirstProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendFirstProject.Infrastructure.Repositories
{
    public class VacationRequestRepository : IVacationRequestRepository
    {
        private readonly AppDbContext _context;

        public VacationRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VacationRequest>> GetAllAsync()
        {
            return await _context.VacationRequests.ToListAsync();
        }

        public async Task<VacationRequest> GetByIdAsync(int requestId)
        {
            return await _context.VacationRequests.FindAsync(requestId);
        }

        public async Task<IEnumerable<VacationRequest>> GetByEmployeeNumberAsync(string employeeNumber)
        {
            return await _context.VacationRequests
                .Where(vr => vr.EmployeeNumber == employeeNumber)
                .ToListAsync();
        }

        public async Task<IEnumerable<VacationRequest>> GetPendingRequestsAsync()
        {
            // Assuming RequestStateId = 1 means 'Submitted' 
                        return await _context.VacationRequests
                 .Include(vr => vr.Employee)
                 .Include(vr => vr.VacationType)
                 .Include(vr => vr.RequestState)
                 .Where(vr => vr.RequestStateId == 1)
                 .ToListAsync();
        }
        public async Task AddAsync(VacationRequest request)
        {
            _context.VacationRequests.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VacationRequest request)
        {
            _context.VacationRequests.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int requestId)
        {
            var request = await GetByIdAsync(requestId);
            if (request != null)
            {
                _context.VacationRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}
