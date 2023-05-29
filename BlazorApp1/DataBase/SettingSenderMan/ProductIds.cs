using System;
using System.Collections.Generic;

namespace BlazorApp1.Database.SettingSenderMan;

public partial class ProductIds
{
    public int Id { get; set; }

    public int ProdId { get; set; }

    public string? Name { get; set; }

    public string? Potrebitel { get; set; }

    public string? SettingSenderManMailProgrammSend { get; set; }

    public virtual SettingSenderManMails? SettingSenderManMailProgrammSendNavigation { get; set; }
}
