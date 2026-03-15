using TenantFlow.Domain.Common;
using TenantFlow.Domain.Enums;
using TenantFlow.Domain.Exceptions;

namespace TenantFlow.Domain.Entities;

public class User : AuditableEntity
{
    public Guid TenantId { get; private set; }

    public string Name { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    public string PasswordHash { get; private set; } = null!;

    public Role Role { get; private set; }

    public bool IsActive { get; private set; }

    private User() { } // EF Core

    public static User Create(Guid tenantId, string name, string email, string passwordHash, Role role)
    {
        if (tenantId == Guid.Empty)
            throw new DomainException("TenantId is required.");

        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required.");

        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email is required.");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new DomainException("PasswordHash is required.");

        return new User
        {
            TenantId = tenantId,
            Name = name,
            Email = email,
            PasswordHash = passwordHash,
            Role = role,
            IsActive = true
        };
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;

    public void ChangeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email is required.");

        Email = email;
        SetUpdatedAt();
    }

    public void ChangeRole(Role role)
    {
        Role = role;
        SetUpdatedAt();
    }
}
