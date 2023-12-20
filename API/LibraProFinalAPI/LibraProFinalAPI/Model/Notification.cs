using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Model;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string NotificationDetails { get; set; } = null!;

    public DateTime NotificationDate { get; set; }

    public int UserId { get; set; }

    public string NotificationTitle { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
