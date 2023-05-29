using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Checkpoints.CheckPointPackaging;

public partial class CheckPointDataPackages
{
    public string BarCode { get; set; } = null!;

    public string? PackageSerial { get; set; }

    public virtual ICollection<CheckPointData> CheckPointData { get; set; } = new List<CheckPointData>();

    public virtual CheckPointDataSerials? PackageSerialNavigation { get; set; }
}
