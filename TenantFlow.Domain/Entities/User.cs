using TenantFlow.Domain.Common;
using TenantFlow.Domain.Enums;

namespace TenantFlow.Domain.Entities;

public class User : BaseEntity
{
    public Guid TenantId { get; set; }

    public string Name { get; private set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public Role Role { get; set; }

    public bool IsActive { get; set; }
}
