using System;
using System.Collections.Generic;

namespace BlazorApp1.Database.SettingSenderMan;

public partial class CopyMails
{
    public int Id { get; set; }

    public string? Mail { get; set; }

    public string? SettingSenderManMailProgrammSend { get; set; }

    public virtual SettingSenderManMails? SettingSenderManMailProgrammSendNavigation { get; set; }
}
