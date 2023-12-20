using App2.dto;
using App2.Helper;
using App2.Middleware;
using App2.Models;
using App2.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App2.Services
{
    public class NotificationServices : INotifciationServices
    {

        private readonly INotificationManager notificationmanager;
        APIServices _apiservice = new APIServices();

        public NotificationServices()
        {
            this.notificationmanager = DependencyService.Get<INotificationManager>();
        }

        // Function used to get sample notifications for testing
        public async Task<IEnumerable<NotificationModel>> GetSampleNotificationsAsync()
        {
            List<NotificationModel> Notificationlist = new List<NotificationModel>();

            // Create and add sample notifications to the list
            Notificationlist.Add(new NotificationModel { NotificationDetails = "Sample Notification 1" });
            Notificationlist.Add(new NotificationModel { NotificationDetails = "Sample Notification 2" });

            // Update the notification count
            Settings.NumNotifications = Notificationlist.Count;

            return await Task.FromResult(Notificationlist);
        }

        public void ShowNotification(string title, string message)
        {
           notificationmanager.ScheduleNotification(title, message);    

        }


        public async Task<IEnumerable<NotificationModel>> GetNotificationsAsync(string _token)
        {
            List<NotificationModel> Booklist = new List<NotificationModel>();
            HttpClient client = new HttpClient();

            string url = _apiservice.baseUrl+"Notification/usernotification";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string Content = response.Content.ReadAsStringAsync().Result;
                Booklist = JsonConvert.DeserializeObject<List<NotificationModel>>(Content);
                Settings.NumNotifications = Booklist.Count;
            }
            return await Task.FromResult(Booklist);
        }


        public async Task<bool> EditNotification(int _NotID, string _token)
        {
            HttpClient client = new HttpClient();

            var NotNodel = new EditNotification
            {
                NotificationId = _NotID
            };

            var json = JsonConvert.SerializeObject(NotNodel);
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await client.PostAsync(_apiservice.baseUrl + "Notification/editnotifstatus", content);
            var cont = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode;

        }
    }
}
