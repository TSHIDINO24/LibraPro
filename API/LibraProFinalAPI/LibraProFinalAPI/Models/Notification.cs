using System;
using System.Collections.Generic;

namespace LibraProFinalAPI.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string NotificationDetails { get; set; } = null!;

    public DateTime NotificationDate { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
