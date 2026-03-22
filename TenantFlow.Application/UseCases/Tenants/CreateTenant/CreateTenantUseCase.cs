using TenantFlow.Application.Interfaces.Repositories;
using TenantFlow.Domain.Entities;

namespace TenantFlow.Application.UseCases.Tenants.CreateTenant;

public class CreateTenantUseCase
{
    private readonly ITenantRepository _tenantRepository;

    public CreateTenantUseCase(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }

    public async Task<CreateTenantResponse> ExecuteAsync(CreateTenantRequest request)
    {
        var alreadyExists = await _tenantRepository.ExistsByEmailAsync(request.Email);

        if (alreadyExists)
            throw new InvalidOperationException("A tenant with this email already exists.");

        var tenant = Tenant.Create(request.Name, request.Email);

        await _tenantRepository.AddAsync(tenant);

        return new CreateTenantResponse(tenant.Id, tenant.Name, tenant.Email);
    }
}
