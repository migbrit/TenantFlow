using TenantFlow.Domain.Common;
using TenantFlow.Domain.Enums;
using TenantFlow.Domain.Exceptions;

namespace TenantFlow.Domain.Entities;

public class Contract : AuditableEntity
{
    public Guid TenantId { get; private set; }

    public Guid ClientId { get; private set; }

    public string Title { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public decimal Value { get; private set; }

    public ContractStatus Status { get; private set; }

    private Contract() { } // EF Core

    public static Contract Create(Guid tenantId, Guid clientId, string title, string description, DateTime startDate, DateTime endDate, decimal value)
    {
        if (tenantId == Guid.Empty)
            throw new DomainException("TenantId is required.");

        if (clientId == Guid.Empty)
            throw new DomainException("ClientId is required.");

        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Title is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Description is required.");

        if (endDate <= startDate)
            throw new DomainException("EndDate must be after StartDate");

        if (value <= 0)
            throw new DomainException("Value must be greater than zero.");

        return new Contract
        {
            TenantId = tenantId,
            ClientId = clientId,
            Title = title,
            Description = description,
            StartDate = startDate,
            EndDate = endDate,
            Value = value,
            Status = ContractStatus.Pending
        };
    }

    public void Activate()
    {
        if (Status == ContractStatus.Active)
            throw new DomainException("Contract is already active.");

        Status = ContractStatus.Active;
    }

    public void Suspend()
    {
        if (Status != ContractStatus.Active)
            throw new DomainException("Only active contracts can be suspended.");

        Status = ContractStatus.Suspended;
    }

    public void Cancel()
    {
        if (Status == ContractStatus.Cancelled)
            throw new DomainException("Contract is already cancelled.");

        Status = ContractStatus.Cancelled;
    }
}

