﻿using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Permissions;

public partial class EmployeesList
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmployeeLogin { get; set; }

    public string? EmployeeCard { get; set; }

    public virtual ICollection<PermissionRules> PermissionRules { get; set; } = new List<PermissionRules>();
}
