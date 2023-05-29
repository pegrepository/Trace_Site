using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Products;

public partial class ProductPackingLists
{
    public int PackingListId { get; set; }

    public string? PackingListName { get; set; }

    public byte[]? PackingListImage { get; set; }

    public virtual ICollection<ProductTags> ProductTags { get; set; } = new List<ProductTags>();
}
