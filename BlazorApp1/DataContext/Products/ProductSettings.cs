using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Products;

public partial class ProductSettings
{
    public int ProductId { get; set; }

    public string? Product1C { get; set; }

    public string? ProductName { get; set; }

    public string? ProductConsumer { get; set; }

    public byte[]? ProductImage { get; set; }

    /// <summary>
    /// В столбце &quot;ProductDataJson&quot; содержится:
    /// 1. LastSerial
    /// 2. Prefix
    /// 
    /// </summary>
    public string? ProductSettingsJson { get; set; }

    /// <summary>
    /// В столбце &quot;ProductDataJson&quot; содержится:
    /// 1. LastSerial
    /// 2. Prefix
    /// 
    /// </summary>
    public string? ProductDataJson { get; set; }

    public int? ProductTagId { get; set; }

    public virtual ProductTags? ProductTag { get; set; }
}
