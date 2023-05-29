using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Checkpoints;

public partial class CheckPointsList
{
    public int CheckPointId { get; set; }

    public string? CheckPointName { get; set; }

    public string? CheckPointIp { get; set; }

    public string? CheckPointSettingsJson { get; set; }

    public string? CheckPointDataJson { get; set; }
}
