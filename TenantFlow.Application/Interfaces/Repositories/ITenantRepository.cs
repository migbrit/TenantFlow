using TenantFlow.Domain.Entities;

namespace TenantFlow.Application.Interfaces.Repositories;

public interface ITenantRepository
{
    Task<Tenant?> GetByIdAsync(Guid id);
    Task<bool> ExistsByEmailAsync(string email);
    Task AddAsync(Tenant tenant);
}
