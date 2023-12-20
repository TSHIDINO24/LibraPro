using App2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        int counter = 0;
        private string _devicetoken;
        public MainPage()
        {
            InitializeComponent();
            if (Preferences.ContainsKey("DeviceToken"))
            {
                _devicetoken = Preferences.Get("DeviceToken","");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var pushNotificationRequest = new PushNotificationRequest
            {
                notification = new NotificationBody
                {
                    title = "Notification Title",
                    content = "Notification Body"
                },
                App_ID = new List<string> { _devicetoken }
            };

            string url = "https://fcm.googleapis.com/fcm/send";

            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("key", "=" + "BIazNVwdrVL82PXl9czHiE2elwGt6-v4sFcANYLyn-XqQPiVrP-Lv4U7ipUmARDQ-Rq51P0DZQscDM2b9M8L3RQ");
                
                string serializerequest = JsonConvert.SerializeObject(pushNotificationRequest);
                var response = await client.PostAsync(url, new StringContent(serializerequest,Encoding.UTF8,"application/json"));

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await App.Current.MainPage.DisplayAlert("", "Notification sent", "ok");
                }
            }
        }
    }
}