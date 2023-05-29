using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Permissions;

public partial class PermissionsList
{
    public int PermissionId { get; set; }

    public string PermissionName { get; set; } = null!;

    public string PermissionLevel { get; set; } = null!;

    public virtual ICollection<PermissionRules> PermissionRules { get; set; } = new List<PermissionRules>();
}
