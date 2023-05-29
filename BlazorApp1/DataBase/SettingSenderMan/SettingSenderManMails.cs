using System;
using System.Collections.Generic;

namespace BlazorApp1.Database.SettingSenderMan;

public partial class SettingSenderManMails
{
    public string ProgrammSend { get; set; } = null!;

    public int NumberSend { get; set; }

    public DateTime PreviosSend { get; set; }

    public string? SubjectMail { get; set; }

    public string? BodyMail { get; set; }

    public string? StructMail { get; set; }

    public virtual ICollection<ClientMails> ClientMails { get; set; } = new List<ClientMails>();

    public virtual ICollection<CopyMails> CopyMails { get; set; } = new List<CopyMails>();

    public virtual ICollection<ProductIds> ProductIds { get; set; } = new List<ProductIds>();
}
