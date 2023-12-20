using App2.Helper;
using App2.Services;
using App2.ViewModels;
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
    public partial class LoginPage : ContentPage
    {
        private UserServices _userservices = new UserServices();
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool user = await _userservices.LoginAsync(txtemail.Text, txtpass.Text);
            //Settings.token = user;
            if(user == true)
            {

                await Navigation.PushAsync(new FlyoutHome());
            }
            else
            {
                await DisplayAlert("", "Email or Password is incorrect", "ok");
               
            }
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}