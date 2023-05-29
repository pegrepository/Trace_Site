using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Traceability;

public partial class Global
{
    public string BarCode { get; set; } = null!;

    public string? ProductId { get; set; }

    public DateTime? CheckTime { get; set; }

    public int LastCheckPointId { get; set; }

    public bool Result { get; set; }

    public string? LastCheckPointErrors { get; set; }
}
