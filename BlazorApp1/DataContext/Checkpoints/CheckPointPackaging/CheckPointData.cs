using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Checkpoints.CheckPointPackaging;

public partial class CheckPointData
{
    public string IdAndBarCode { get; set; } = null!;

    public string? ProductKey { get; set; }

    public string? ServerName { get; set; }

    public string? BarCode { get; set; }

    public string? SerialNumber { get; set; }

    public string? QrReadData { get; set; }

    public DateTime PackData { get; set; }

    public string? CardSequrity { get; set; }

    public string? Iccid { get; set; }

    public string? VimIccid { get; set; }

    public string? Imei { get; set; }

    public virtual CheckPointDataPackages? BarCodeNavigation { get; set; }
}
