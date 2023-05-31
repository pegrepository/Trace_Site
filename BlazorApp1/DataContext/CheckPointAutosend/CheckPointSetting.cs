using System;
using System.Collections.Generic;

namespace BlazorApp1.DataContext.CheckPointAutosend;

public partial class CheckPointSetting
{
    public int ProgramId { get; set; }

    public int NumberSend { get; set; }

    public DateTime PreviousSend { get; set; }

    public string? SubjectMail { get; set; }

    public string? BodyMail { get; set; }

    public string? StructMail { get; set; }

    public string? ProductsJson { get; set; }

    public string? ClientMailsJson { get; set; }

    public string? CopyMailsJson { get; set; }
}
