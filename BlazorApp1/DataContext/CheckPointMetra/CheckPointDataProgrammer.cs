using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.CheckPointMetra;

public partial class CheckPointDataProgrammer
{
    public int Id { get; set; }

    public int Ku { get; set; }

    public string? ProductName { get; set; }

    public string? ProductVersion { get; set; }

    public bool Result { get; set; }

    public DateTime TimeStart { get; set; }

    public DateTime TimeStop { get; set; }

    public string? Error { get; set; }

    public string? Logs { get; set; }

    public string? LocalBarCode { get; set; }

    public virtual CheckPointData? LocalBarCodeNavigation { get; set; }
}
