using AndroidApp = Android.App.Application;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using AndroidX.Core.App;
using Android.Graphics;

[assembly: Xamarin.Forms.Dependency(typeof(App2.Droid.AndroidNotificationManager))]
namespace App2.Droid
{
    public class AndroidNotificationManager : INotificationManager
    {
        private const string defaultChannelId = "localNotification";
        private const string defaultChannelName = "General Notification";
        private const string defaultChannelDescription = "This is the general notification for application.";
        private const int pendingIntendId =0;
        private bool channelInitialized;
        private int messageId;
        private NotificationManager _notificationmanager;

        public void Intialize()
        {
            throw new NotImplementedException();
        }

        public void ReceiveNotification(string _Title, string _message)
        {
            throw new NotImplementedException();
        }

        public void ScheduleNotification(string _Title, string _message)
        {
            if (!channelInitialized)
            {
                CreateNotificationChannel();
            }

            Intent intent = new Intent(AndroidApp.Context,typeof(MainActivity));

            intent.PutExtra("title", _Title);
            intent.PutExtra ("message", _message);
            messageId++;

            PendingIntent pendingIntent = PendingIntent.GetActivity(AndroidApp.Context, pendingIntendId, intent, PendingIntentFlags.OneShot);
            NotificationCompat.Builder builder = new NotificationCompat.Builder(AndroidApp.Context, defaultChannelId)
                .SetContentIntent(pendingIntent)
                .SetDefaults(NotificationCompat.DefaultAll)
                .SetContentTitle(_Title)
                .SetContentText(_message)
                .SetLargeIcon(BitmapFactory.DecodeResource(AndroidApp.Context.Resources, Resource.Mipmap.icon_round))
                .SetSmallIcon(Resource.Mipmap.icon_round)
                .SetAutoCancel(true);

            Notification notification = builder.Build();
            _notificationmanager.Notify(messageId, notification);   

        }

        private void CreateNotificationChannel()
        {
            _notificationmanager = (NotificationManager)AndroidApp.Context.GetSystemService(AndroidApp.NotificationService);
           
            //if API >= 26 then create a channel for notification
            if(Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelNameJava = new Java.Lang.String(defaultChannelName);
                var channel = new NotificationChannel(defaultChannelId, channelNameJava, NotificationImportance.High)
                {
                    Description = defaultChannelDescription
                };

                _notificationmanager.CreateNotificationChannel(channel);

            }

            channelInitialized = true;
        }
    }
}