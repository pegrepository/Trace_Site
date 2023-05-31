using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.CheckPointPackaging;

public partial class CheckPointSetting
{
    public int ProductId { get; set; }

    public int CheckPointId { get; set; }

    public string CheckPointName { get; set; } = null!;

    public string CheckPointIp { get; set; } = null!;
}
