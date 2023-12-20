using App2.Helper;
using App2.Models;
using App2.Services;
using App2.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationPage : ContentPage
    {
        private readonly NotificationViewModel _notificationViewModel;
        private readonly NotificationServices _notificationServices; // Add this field

        public NotificationPage()
        {
            InitializeComponent();
            this.BindingContext = _notificationViewModel = new NotificationViewModel();
           

            // Initialize the NotificationServices
            //_notificationServices = new NotificationServices();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(Settings.NumNotifications <= 0)
            {
                NotificationPresent.IsVisible = true;
            }
            foreach(NotificationModel item in NotClicked.ItemsSource)
            {
                if(item.Status == "sent")
                {
                    
                }
            }
            NumNotifications.Text = Convert.ToString(Settings.NumNotifications);
            _notificationViewModel.OnAppearing();
        }

        private async void notificationListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string _token = Settings.token;
            var mynotification = e.Item as NotificationModel;
            
            //if(mynotification.Status == "sent")
            //{
            //    await _notificationServices.EditNotification(Convert.ToInt32(mynotification.NotificationId),_token);
            //    await Navigation.PushAsync(new ViewNotificationPage(mynotification.NotificationTitle, mynotification.NotificationDetails, mynotification.NotificationDate));
            //}
            await Navigation.PushAsync(new ViewNotificationPage(mynotification.NotificationTitle, mynotification.NotificationDetails, mynotification.NotificationDate));
        }
    }
}
