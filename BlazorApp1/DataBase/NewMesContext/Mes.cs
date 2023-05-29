using System;
using System.Collections.Generic;

namespace BlazorApp1.DataBase.NewMesContext;

public partial class Mes
{
    public string BarCode { get; set; } = null!;

    public int ProductId { get; set; }

    public DateTime TimeCheck { get; set; }

    public bool ResultTest { get; set; }

    public virtual ICollection<Pg> Pgs { get; set; } = new List<Pg>();

    public virtual ICollection<Printer> Printers { get; set; } = new List<Printer>();

    public virtual ICollection<Ufk1> Ufk1 { get; set; } = new List<Ufk1>();

    public virtual ICollection<Ufk3> Ufk3 { get; set; } = new List<Ufk3>();
}
