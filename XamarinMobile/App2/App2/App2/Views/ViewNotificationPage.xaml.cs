using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewNotificationPage : ContentPage
    {
        public ViewNotificationPage(string _NotificationTitle, string _NotificationDetails, DateTime _NotificationDate)
        {
            InitializeComponent();

            NotificationType.Text = _NotificationTitle;
            NotificationDetails.Text = _NotificationDetails;
            NotificationDate.Text = Convert.ToString(_NotificationDate);
        }
    }
}