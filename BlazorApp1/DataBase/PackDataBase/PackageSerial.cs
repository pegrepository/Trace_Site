using System;
using System.Collections.Generic;

namespace BlazorApp1.DataBase.PackDataBase;

public partial class PackageSerial
{
    public string Serial { get; set; } = null!;

    public int? ProductId { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<ProductsInPackage> ProductsInPackages { get; set; } = new List<ProductsInPackage>();
}
