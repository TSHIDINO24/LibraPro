using App2.Helper;
using App2.Services;
using App2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public APIServices _apiservice = new APIServices();
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public Command LoginCommand 
        {
            get
            {
                return new Command(async () =>
                {
                    //var _token = await _apiservice.LoginAsync(UserEmail,UserPassword);

                   // Settings.token = _token;
                });
            }
        }

        public LoginViewModel()
        {
            //LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
