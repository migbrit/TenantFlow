using TenantFlow.Domain.Common;
using TenantFlow.Domain.Exceptions;

namespace TenantFlow.Domain.Entities;

public class Client : AuditableEntity
{
    public Guid TenantId { get; private set; }

    public string Name { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    public string Document { get; private set; } = null!;

    public bool IsActive { get; private set; }

    private Client() { } // EF Core

    public static Client Create(Guid tenantId, string name, string email, string document)
    {
        if (tenantId == Guid.Empty)
            throw new DomainException("TenantId is required.");

        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required.");

        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email is required.");

        if (string.IsNullOrWhiteSpace(document))
            throw new DomainException("Document is required.");

        return new Client
        {
            TenantId = tenantId,
            Name = name,
            Email = email,
            Document = document,
            IsActive = true
        };
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;

    public void Update(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required.");

        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email is required.");

        Name = name;
        Email = email;
        SetUpdatedAt();
    }
}
