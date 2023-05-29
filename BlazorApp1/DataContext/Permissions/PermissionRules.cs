using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Permissions;

public partial class PermissionRules
{
    public int RuleId { get; set; }

    public string? RuleName { get; set; }

    public int EmployeeId { get; set; }
    public int CheckPointId { get; set; }

    public int PermissionId { get; set; }

    public int WebSitePageId { get; set; }

    public virtual EmployeesList Employee { get; set; } = null!;

    public virtual PermissionsList Permission { get; set; } = null!;

    public virtual WebSitePagesList WebSitePage { get; set; } = null!;
}
