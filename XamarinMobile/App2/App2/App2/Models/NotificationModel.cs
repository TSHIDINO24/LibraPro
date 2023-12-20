using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public  class NotificationModel
    {
        public int NotificationId { get; set; }
        public string NotificationDetails { get; set; }

        public DateTime NotificationDate { get; set; }

        public string NotificationTitle { get; set; }

        public string Status { get; set; }
    }
}
