using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Middleware
{
    public interface INotificationManager
    {
        void Intialize();
        void ScheduleNotification(string _Title, string _message);

        void ReceiveNotification(string _Title, string _message);
 
    }
}
