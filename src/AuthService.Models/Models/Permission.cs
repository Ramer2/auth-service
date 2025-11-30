using System;
using System.Collections.Generic;

namespace AuthService.DAL;

public partial class Permission
{
    public Guid PermissionId { get; set; }

    public string PermissionName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
