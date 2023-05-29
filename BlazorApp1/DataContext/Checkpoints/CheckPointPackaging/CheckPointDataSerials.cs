using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Checkpoints.CheckPointPackaging;

public partial class CheckPointDataSerials
{
    public string Serial { get; set; } = null!;

    public int? ProductId { get; set; }

    public DateTime? Date { get; set; }

    public int Id { get; set; }

    public virtual ICollection<CheckPointDataPackages> CheckPointDataPackages { get; set; } = new List<CheckPointDataPackages>();
}
