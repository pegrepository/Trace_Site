using System;
using System.Collections.Generic;

namespace BlazorApp1.DataBase.PackDataBase;

public partial class ProductsInPackage
{
    public string BarCode { get; set; } = null!;

    public string? PackageSerial { get; set; }

    public virtual PackageSerial? PackageSerialNavigation { get; set; }
}
