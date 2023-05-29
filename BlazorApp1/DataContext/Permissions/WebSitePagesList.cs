using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Permissions;

public partial class WebSitePagesList
{
    public int WebSitePageId { get; set; }

    public string? WebSitePageName { get; set; }

    public virtual ICollection<PermissionRules> PermissionRules { get; set; } = new List<PermissionRules>();
}
