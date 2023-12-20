using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class PushNotificationRequest
    {
        public List<string> App_ID { get; set; } = new List<string>();
        public NotificationBody notification { get; set; }

        public object data { get; set; }
    }

    public class NotificationBody
    {
        public string title { get; set; }
        public string content { get; set; }
    }
}
