using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.Products;

public partial class ProductTags
{
    public int TagId { get; set; }

    public string? TagName { get; set; }

    public int? TagParametersId { get; set; }

    public int? TagLabelId { get; set; }

    public int? TagPackingListId { get; set; }

    public int? TagPassportId { get; set; }

    public virtual ICollection<ProductSettings> ProductSettings { get; set; } = new List<ProductSettings>();

    public virtual ProductLabels? TagLabel { get; set; }

    public virtual ProductPackingLists? TagPackingList { get; set; }

    public virtual ProductTagParameters? TagParameters { get; set; }

    public virtual ProductPassports? TagPassport { get; set; }
}
