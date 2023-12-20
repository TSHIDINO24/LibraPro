using App2.Helper;
using App2.Models;
using App2.Services;
using App2.Services.Interfaces;
using MvvmHelpers.Commands;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModels
{
    public class NotificationViewModel : BaseCatViewModel
    {
        NotificationServices _notificationservice = new NotificationServices();
        public Command LoadNotificatinCommand { get; }


        private readonly INotifciationServices notifciationServices;
        public DelegateCommand LcalNotificationCommand { get; private set; }

        public int NotificationCounter { get; set; }
        public ObservableCollection<NotificationModel> Notificationlist { get; }

        public ObservableCollection<FineModel> _fine { get; }
        public NotificationViewModel()
        {
            Notificationlist = new ObservableCollection<NotificationModel>();
            LoadNotificatinCommand = new Command(async () => await LoadNotifcationCommand());


            LcalNotificationCommand = new DelegateCommand(ShowNotification);
            //this.notifciationServices = notifciationservices;
        }

        private void ShowNotification()
        {
           notifciationServices.ShowNotification("New Message", "This is a local notification");
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
        



        private async Task LoadNotifcationCommand()
        {
            IsBusy = true;
            try
            {
                Notificationlist.Clear();
                string _token = Settings.token;
                var catlist = await _notificationservice.GetNotificationsAsync(_token);
                foreach (var cat in catlist)
                {
                    Notificationlist.Add(cat);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

       

    }
}
