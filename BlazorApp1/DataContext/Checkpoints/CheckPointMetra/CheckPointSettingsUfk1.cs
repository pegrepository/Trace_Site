using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Checkpoints.CheckPointMetra;

public partial class CheckPointSettingsUfk1
{
    public int Id { get; set; }

    public byte[]? Step { get; set; }

    public int MinVal { get; set; }

    public int MaxVal { get; set; }

    public int ProductId { get; set; }

    public virtual CheckPointSetting Product { get; set; } = null!;
}
