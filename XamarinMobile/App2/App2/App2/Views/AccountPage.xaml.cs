using App2.Control;
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
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TranslateFrame(Frame1);
            TranslateFrame(Frame2);
            TranslateFrame(Frame3);
            TranslateFrame(Frame4);
            TranslateFrame(Frame5);

        }

        private void TranslateFrame(FrameView frame)
        {
            Task.Run(async () =>
            {
                await frame.RotateYTo(-360, 600); ;
            });
        }

        private void PersonalDetails_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PersonalDetailsPage());
        }

        private void ChangePassword_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage());
        }

        private void Fines_Tapped(object sender, EventArgs e)
        {

        }

        private void Notification_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotificationPage());
        }

        private void SignOut_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}