using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Products;

public partial class ProductPassports
{
    public int PassportId { get; set; }

    public string? PassportName { get; set; }

    public byte[]? PassportImage { get; set; }

    public virtual ICollection<ProductTags> ProductTags { get; set; } = new List<ProductTags>();
}
