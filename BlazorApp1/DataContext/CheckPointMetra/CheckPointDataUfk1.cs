using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.CheckPointMetra;

public partial class CheckPointDataUfk1
{
    public int Id { get; set; }

    public int Ku { get; set; }

    public string? Serial { get; set; }

    public string? GlonassPassword { get; set; }

    public string? TechRom { get; set; }

    public byte ProgrammKod { get; set; }

    public bool Vch { get; set; }

    public DateTime TimeStart { get; set; }

    public DateTime TimeStop { get; set; }

    public byte[]? TestData { get; set; }

    public string? Jsontest { get; set; }

    public string? Error { get; set; }

    public bool Result { get; set; }

    public string? LocalBarCode { get; set; }

    public virtual CheckPointData? LocalBarCodeNavigation { get; set; }
}
