using System.Collections.Generic;
using System.Threading.Tasks;
using BackendFirstProject.Core.Entities;

namespace BackendFirstProject.Core.Interfaces
{
    public interface IVacationRequestRepository
    {
        Task<IEnumerable<VacationRequest>> GetAllAsync();
        Task<VacationRequest> GetByIdAsync(int requestId);
        Task<IEnumerable<VacationRequest>> GetByEmployeeNumberAsync(string employeeNumber);
        Task<IEnumerable<VacationRequest>> GetPendingRequestsAsync();
        Task AddAsync(VacationRequest request);
        Task UpdateAsync(VacationRequest request);
        Task DeleteAsync(int requestId);
    }
}
