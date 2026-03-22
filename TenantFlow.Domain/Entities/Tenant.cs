using TenantFlow.Domain.Common;
using TenantFlow.Domain.Exceptions;

namespace TenantFlow.Domain.Entities;

public class Tenant : AuditableEntity
{
    public string Name { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    public bool IsActive { get; private set; }

    private Tenant() { }  // EF Core

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;

    public static Tenant Create (string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required.");

        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email is required.");

        return new Tenant
        {
            Name = name,
            Email = email,
            IsActive = true
        };
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name cannot be empty.");

        Name = name;
        SetUpdatedAt();
    }

    public void ChangeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email cannot be empty.");

        Email = email;
        SetUpdatedAt();
    }
}