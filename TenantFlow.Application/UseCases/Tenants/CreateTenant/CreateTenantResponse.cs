namespace TenantFlow.Application.UseCases.Tenants.CreateTenant;

public record CreateTenantResponse(Guid Id, string Name, string Email);
