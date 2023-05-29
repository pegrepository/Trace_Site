using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Products;

public partial class ProductLabels
{
    public int LabelId { get; set; }

    public string? LabelName { get; set; }

    public byte[]? LabelImage { get; set; }

    public virtual ICollection<ProductTags> ProductTags { get; set; } = new List<ProductTags>();
}
