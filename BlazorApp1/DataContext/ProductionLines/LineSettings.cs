using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Productionlines;

public partial class LineSettings
{
    public int LineId { get; set; }

    public string? LineName { get; set; }

    public int? LineProductId { get; set; }

    public string? LineCheckPointsJson { get; set; }

    public bool LineZeroCheckPoint { get; set; }
}
