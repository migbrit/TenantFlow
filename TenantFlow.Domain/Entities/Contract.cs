using TenantFlow.Domain.Common;
using TenantFlow.Domain.Enums;
using TenantFlow.Domain.Exceptions;

namespace TenantFlow.Domain.Entities;

public class Contract : BaseEntity
{
    public Guid TenantId { get; set; }

    public Guid CustomerId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Value { get; set; }

    public ContractStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public void Activate()
    {
        if (Status == ContractStatus.Active)
            throw new DomainException("Contract is already active");

        Status = ContractStatus.Active;
    }

    public void Inactivate()
    {
        Status = ContractStatus.Inactive;
    }

    public void Suspend()
    {
        Status = ContractStatus.Suspended;
    }

    public void Pending()
    {
        Status = ContractStatus.Pending;
    }
}

