using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using Firebase.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace App2.Droid.services
{
    [Service(Exported = true)]
    [IntentFilter(new[] {"com.google.firebase.MESSAGING_EVENT"})]
    public class FirebaseService : FirebaseMessagingService
    {
        public FirebaseService()
        {

        }


        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);
            if (Preferences.ContainsKey("DeviceToken"))
            {
                Preferences.Remove("DeviceToken");
            }
            Preferences.Set("DeviceToken", token);
           
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            var notification = message.GetNotification();
            SendNotification(notification.Body, notification.Title, message.Data); 
        }

        private void SendNotification(string messagebody, string title, IDictionary<string, string> data)
        {
            var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.ChannelID)
                .SetContentTitle(title)
                .SetSmallIcon(Resource.Mipmap.icon_round)
                .SetContentText(messagebody)
                .SetChannelId(MainActivity.ChannelID)
                .SetPriority(2);

            var notification = NotificationManagerCompat.From(this);
            notification.Notify(MainActivity.NotificationID, notificationBuilder.Build());
        }
    }
    
}