using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Products;

public partial class ProductTagParameters
{
    public int ParametersId { get; set; }

    public string? TagParametersName { get; set; }

    public string? LabelParametersJson { get; set; }

    public string? PackingListParametersJson { get; set; }

    public string? PassportParametersJson { get; set; }

    public virtual ICollection<ProductTags> ProductTags { get; set; } = new List<ProductTags>();
}
