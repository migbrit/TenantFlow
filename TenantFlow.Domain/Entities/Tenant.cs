using TenantFlow.Domain.Common;
using TenantFlow.Domain.Exceptions;

namespace TenantFlow.Domain.Entities;

public class Tenant : AuditableEntity
{
    public string Name { get; private set; }

    public string Email { get; private set; }

    public bool IsActive { get; private set; }

    private Tenant() { }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name cannot be empty.");

        Name = name;
    }

    public void ChangeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email cannot be empty.");

        Email = email;
    }
}